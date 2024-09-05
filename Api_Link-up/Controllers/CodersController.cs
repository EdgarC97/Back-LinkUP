using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Link_up.Data;
using Api_Link_up.DTOS;
using Api_Link_up.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_Link_up.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CodersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CodersController(AppDbContext context)
        {
            _context = context;
        }

        //GET
        [HttpGet]
        public async Task<IActionResult> GetCoders(
            [FromQuery] string languageName = null,
            [FromQuery] string genderName = null,
            [FromQuery] string softSkillName = null,
            [FromQuery] string technicalSkillName = null)
        {
            var query = _context.Coders
                .Include(c => c.Gender)
                .Include(c => c.CoderSoftSkills)
                    .ThenInclude(css => css.SoftSkill)
                .Include(c => c.CoderLanguageLevels)
                    .ThenInclude(cll => cll.LanguageLevel)
                        .ThenInclude(ll => ll.Language)
                .Include(c => c.CoderTechnicalSkillLevels)
                    .ThenInclude(ctsl => ctsl.TechnicalSkillLevel)
                        .ThenInclude(tsl => tsl.TechnicalSkill)
                .AsQueryable();

            if (!string.IsNullOrEmpty(languageName))
            {
                query = query.Where(c => c.CoderLanguageLevels
                    .Any(cll => cll.LanguageLevel.Language.Name.ToLower() == languageName.ToLower()));
            }

            if (!string.IsNullOrEmpty(genderName))
            {
                query = query.Where(c => c.Gender.Name.ToLower() == genderName.ToLower());
            }

            if (!string.IsNullOrEmpty(softSkillName))
            {
                query = query.Where(c => c.CoderSoftSkills
                    .Any(css => css.SoftSkill.Name.ToLower() == softSkillName.ToLower()));
            }

            if (!string.IsNullOrEmpty(technicalSkillName))
            {
                query = query.Where(c => c.CoderTechnicalSkillLevels
                    .Any(ctsl => ctsl.TechnicalSkillLevel.TechnicalSkill.Name.ToLower() == technicalSkillName.ToLower()));
            }

            var coders = await query.ToListAsync();
            return Ok(coders);
        }

        //GET / id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCoder(int id)
        {
            var coder = await _context.Coders
                .Include(c => c.Gender)
                .Include(c => c.CoderSoftSkills)
                    .ThenInclude(css => css.SoftSkill)
                .Include(c => c.CoderLanguageLevels)
                    .ThenInclude(cll => cll.LanguageLevel)
                        .ThenInclude(ll => ll.Language)
                .Include(c => c.CoderTechnicalSkillLevels)
                    .ThenInclude(ctsl => ctsl.TechnicalSkillLevel)
                        .ThenInclude(tsl => tsl.TechnicalSkill)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (coder == null)
            {
                return NotFound();
            }

            return Ok(coder);
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> CreateCoder([FromBody] CoderCreationDto coderDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gender = await _context.Genders.FindAsync(coderDto.GenderId);
            if (gender == null)
            {
                return BadRequest("El género especificado no existe.");
            }

            var coder = new Coder
            {
                Name = coderDto.Name,
                Birthday = coderDto.Birthday,
                Description = coderDto.Description,
                UrlImage = coderDto.UrlImage,
                GenderId = coderDto.GenderId
            };

            _context.Coders.Add(coder);
            await _context.SaveChangesAsync();

            // Agregar relaciones
            await AddCoderRelationships(coder.Id, coderDto);

            // Crear DTO de respuesta
            var responseDto = await CreateCoderResponseDto(coder.Id);

            return CreatedAtAction(nameof(GetCoder), new { id = coder.Id }, responseDto);
        }

        private async Task AddCoderRelationships(int coderId, CoderCreationDto coderDto)
        {
            foreach (var skillId in coderDto.SoftSkillIds)
            {
                _context.CoderSoftSkills.Add(new CoderSoftSkill { CoderId = coderId, SoftSkillId = skillId });
            }

            foreach (var levelId in coderDto.LanguageLevelIds)
            {
                _context.CoderLanguageLevels.Add(new CoderLanguageLevel { CoderId = coderId, LanguageLevelId = levelId });
            }

            foreach (var levelId in coderDto.TechnicalSkillLevelIds)
            {
                _context.CoderTechnicalSkillLevels.Add(new CoderTechnicalSkillLevel { CoderId = coderId, TechnicalSkillLevelId = levelId });
            }

            await _context.SaveChangesAsync();
        }

        private async Task<CoderResponseDto> CreateCoderResponseDto(int coderId)
        {
            var coder = await _context.Coders
                .Include(c => c.Gender)
                .Include(c => c.CoderSoftSkills).ThenInclude(css => css.SoftSkill)
                .Include(c => c.CoderLanguageLevels).ThenInclude(cll => cll.LanguageLevel)
                .ThenInclude(ll => ll.Language)
                .Include(c => c.CoderTechnicalSkillLevels).ThenInclude(ctsl => ctsl.TechnicalSkillLevel)
                .ThenInclude(tsl => tsl.TechnicalSkill)
                .FirstOrDefaultAsync(c => c.Id == coderId);

            return new CoderResponseDto
            {
                Id = coder.Id,
                Name = coder.Name,
                Birthday = coder.Birthday,
                Description = coder.Description,
                UrlImage = coder.UrlImage,
                GenderId = coder.GenderId,
                GenderName = coder.Gender.Name,
                SoftSkills = coder.CoderSoftSkills.Select(css => css.SoftSkill.Name).ToList(),
                LanguageLevels = coder.CoderLanguageLevels.Select(cll => new LanguageLevelDto
                {
                    LevelName = cll.LanguageLevel.Name,
                    LanguageName = cll.LanguageLevel.Language.Name
                }).ToList(),
                TechnicalSkillLevels = coder.CoderTechnicalSkillLevels.Select(ctsl => new TechnicalSkillDto
                {
                    LevelName = ctsl.TechnicalSkillLevel.Name,
                    TechnicalSkillName = ctsl.TechnicalSkillLevel.TechnicalSkill.Name
                }).ToList()
            };
        }

        //PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCoder(int id, [FromBody] CoderUpdateDto coderDto)
        {
            if (id != coderDto.Id)
            {
                return BadRequest();
            }

            var existingCoder = await _context.Coders
                .Include(c => c.CoderSoftSkills)
                .Include(c => c.CoderLanguageLevels)
                .Include(c => c.CoderTechnicalSkillLevels)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (existingCoder == null)
            {
                return NotFound();
            }

            // Update basic properties
            existingCoder.Name = coderDto.Name;
            existingCoder.Birthday = coderDto.Birthday;
            existingCoder.Description = coderDto.Description;
            existingCoder.UrlImage = coderDto.UrlImage;
            existingCoder.GenderId = coderDto.GenderId;

            // Clear existing relationships
            _context.CoderSoftSkills.RemoveRange(existingCoder.CoderSoftSkills);
            _context.CoderLanguageLevels.RemoveRange(existingCoder.CoderLanguageLevels);
            _context.CoderTechnicalSkillLevels.RemoveRange(existingCoder.CoderTechnicalSkillLevels);

            // Add new relationships
            foreach (var softSkillId in coderDto.SoftSkillIds)
            {
                _context.CoderSoftSkills.Add(new CoderSoftSkill { CoderId = id, SoftSkillId = softSkillId });
            }

            foreach (var levelId in coderDto.LanguageLevelIds)
            {
                _context.CoderLanguageLevels.Add(new CoderLanguageLevel { CoderId = id, LanguageLevelId = levelId });
            }

            foreach (var levelId in coderDto.TechnicalSkillLevelIds)
            {
                _context.CoderTechnicalSkillLevels.Add(new CoderTechnicalSkillLevel { CoderId = id, TechnicalSkillLevelId = levelId });
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        //PATCH
        [HttpPatch("{id}")]
        [Consumes("application/json-patch+json")]
        public async Task<IActionResult> PatchCoder(int id, [FromBody] JsonPatchDocument<Coder> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest("Patch document is null");
            }

            var coder = await _context.Coders.FindAsync(id);

            if (coder == null)
            {
                return NotFound();
            }

            patchDoc.ApplyTo(coder, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _context.SaveChangesAsync();

            return Ok(coder);
        }

        //DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoder(int id)
        {
            var coder = await _context.Coders.FindAsync(id);
            if (coder == null)
            {
                return NotFound();
            }

            _context.Coders.Remove(coder);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CoderExists(int id)
        {
            return _context.Coders.Any(e => e.Id == id);
        }
    }
}
