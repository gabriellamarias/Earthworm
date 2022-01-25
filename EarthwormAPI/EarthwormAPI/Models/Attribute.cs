using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EarthwormAPI.Models
{
    public class Attributes
    {
        public string description { get; set; } 
        public int row_spacing { get; set; } 
        public int spread { get; set; }
        public int height { get; set; }
        public string sowing_method { get; set; }
        public string sun_requirements { get; set; }
        public int growing_degree_days { get; set; }
        public string main_image_path { get; set; }
    }
}
