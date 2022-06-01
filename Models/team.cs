using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CR_back.Models
{
    public class team
    {
        public int teamID { get; set; }
        public int liga_idliga { get; set; }
        public string teamname { get; set; }
       

        public int cost { get; set; }

        public liga liga { get; set; }
        public ICollection<player> player { get; set; }
    }
}
