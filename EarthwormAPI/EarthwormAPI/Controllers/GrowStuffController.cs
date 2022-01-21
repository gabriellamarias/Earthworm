using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using EarthwormAPI.Models;

namespace EarthwormAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GrowStuffController : ControllerBase
    {
        public string plantURL = "https://www.growstuff.org/crops/{0}.json";
        public string baseURL = "https://www.growstuff.org/crops.json";

        public async Task<IActionResult> ViewCrops()
        {
            using (HttpClient client = new HttpClient())
            {
                var plants = new List<Plant>();

                for (var x = 1; x < 200;  x++)
                {
                    var response = await client.GetAsync(string.Format(plantURL, $"/{x}"));
                    var jsonDataAsString = await response.Content.ReadAsStringAsync();
                    var plant = JsonConvert.DeserializeObject<Plant>(jsonDataAsString);

                    plants.Add(plant);
                    
                } 
                var listOfPlants = new OkObjectResult (plants);

                return (listOfPlants);
            }

        }
    }
}
