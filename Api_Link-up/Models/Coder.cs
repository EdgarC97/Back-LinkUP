using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Link_up.Models
{
    public class Coder
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Description { get; set; }
        public string UrlImage { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual ICollection<CoderSoftSkill> CoderSoftSkills { get; set; }
        public virtual ICollection<CoderLanguagesLevel> CoderLanguagesLevels { get; set; }
        public virtual ICollection<CoderTechnicalSkillsLevel> CoderTechnicalSkillsLevels { get; set; }
    }
}