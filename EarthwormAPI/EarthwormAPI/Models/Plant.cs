using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EarthwormAPI.Models
{
    public class Plant
    {
        public Openfarm_data openfarm_data { get; set; }
        public string name { get; set; }
        public string en_wikipedia_url { get; set; }
        public bool perennial { get; set; }
        public int? median_lifespan { get; set; }
        public int? median_days_to_first_harvest { get; set; }
        public int? median_days_to_last_harvest { get; set; }
    }
}
