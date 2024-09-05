using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Link_up.DTOS
{
    public class CoderResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Description { get; set; }
        public string UrlImage { get; set; }
        public int GenderId { get; set; }
        public string GenderName { get; set; }
        public List<string> SoftSkills { get; set; }
        public List<LanguageLevelDto> LanguageLevels { get; set; }
        public List<TechnicalSkillDto> TechnicalSkillLevels { get; set; }
    }
}