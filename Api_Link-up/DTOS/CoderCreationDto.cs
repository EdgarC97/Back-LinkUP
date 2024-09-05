using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Link_up.DTOS
{
    public class CoderCreationDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(255)]
        public string UrlImage { get; set; }

        [Required]
        public int GenderId { get; set; }

        [Required]
        public List<int> SoftSkillIds { get; set; }

        [Required]
        public List<int> LanguageLevelIds { get; set; }

        [Required]
        public List<int> TechnicalSkillLevelIds { get; set; }
    }
}