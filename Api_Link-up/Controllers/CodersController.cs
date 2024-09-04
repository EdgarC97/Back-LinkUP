using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Link_up.Data;
using Api_Link_up.Models;
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

        [HttpPost]
        public async Task<IActionResult> CreateCoder([FromBody] Coder coder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Coders.Add(coder);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCoder), new { id = coder.Id }, coder);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCoder(int id, Coder coder)
        {
            if (id != coder.Id)
            {
                return BadRequest();
            }

            _context.Entry(coder).State = EntityState.Modified;

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
