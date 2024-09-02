using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Link_up.Models
{
    public class CoderLanguagesLevel
    {
        public int Id { get; set; }
        public int CoderId { get; set; }
        public Coder Coder { get; set; }
        public int LanguagesLevelId { get; set; }
        public LanguagesLevel LanguagesLevel { get; set; }
    }
}