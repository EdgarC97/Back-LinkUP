using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Link_up.Models
{
    public class SoftSkill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<CoderSoftSkill> CoderSoftSkills { get; set; }
    }
}