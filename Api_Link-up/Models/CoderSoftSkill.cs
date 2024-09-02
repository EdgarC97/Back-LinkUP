using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Link_up.Models
{
    public class CoderSoftSkill
    {
        public int Id { get; set; }
        public int CoderId { get; set; }
        public Coder Coder { get; set; }
        public int SoftSkillId { get; set; }
        public SoftSkill SoftSkill { get; set; }
    }
}