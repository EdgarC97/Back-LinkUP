using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Link_up.Models
{
    public class CoderLanguageLevel
    {
        public int CoderId { get; set; }
        public Coder Coder { get; set; }
        
        public int LanguageLevelId { get; set; }
        public LanguageLevel LanguageLevel { get; set; }
    }
}