using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CR_back.Models
{
    public class Country
    {
        public int CountryID { get; set; }
        public string country_name { get; set; }

        public int ligaID { get; set; }
        public liga liga { get; set; }

    }
}
