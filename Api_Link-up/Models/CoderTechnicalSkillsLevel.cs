using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Link_up.Models
{
    public class CoderTechnicalSkillsLevel
    {
        public int Id { get; set; }
        public int CoderId { get; set; }
        public Coder Coder { get; set; }
        public int TechnicalSkillsLevelId { get; set; }
        public TechnicalSkillsLevel TechnicalSkillsLevel { get; set; }
    }
}