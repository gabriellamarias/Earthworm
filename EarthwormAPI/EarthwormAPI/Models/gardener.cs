using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EarthwormAPI.Models
{
    public class gardener
    {
        [Key]
        public int id { get; set; }
        public string username { get; set; }
        public int gardenId { get; set; }
    }
}
