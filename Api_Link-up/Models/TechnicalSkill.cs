using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Link_up.Models
{
    public class TechnicalSkill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<CoderTechnicalSkillsLevel> CoderTechnicalSkillsLevels { get; set; }
    }
}