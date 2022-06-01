using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CR_back.Models
{
    public class player
    {
        public int playerID { get; set; }
        public int inTeamID { get; set; }
        public string PlayerName { get; set; }
        public string position { get; set; }
        public int cost { get; set; }
        public team team { get; set; }
    }
}
