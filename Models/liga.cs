using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CR_back.Models
{
    public class liga
    {
        public int ligaID { get; set; }
        public int InCountryID { get; set; }
        public string liga_name { get; set; }

        public Country Country { get; set; }
        public ICollection<team> team { get; set; } 
    }
}
