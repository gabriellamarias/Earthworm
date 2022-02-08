using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using EarthwormAPI.Models;
using System.Dynamic;
using Newtonsoft.Json.Converters;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace EarthwormAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GrowStuffController : ControllerBase
    {
        private readonly IMemoryCache _cache;
        public string plantURL = "https://www.growstuff.org/crops/{0}.json";
        public string baseURL = "https://www.growstuff.org/crops.json";
        public string plantURLByName = " http://growstuff.org/crops/{name}.json";
        public GrowStuffController(ILogger<GrowStuffController> logger, IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }

        [HttpGet("{plantname}")]
        [Route("plantname")]
        public async Task<IActionResult> GetPlantByName([FromQuery]string plantname)
        {
            String s = "";

            try
            {
                plantname = plantname.ToLower();
                for (int i = 0; i < plantname.Length; ++i)
                {

                    // Changing the ith character
                    // to '-' if it's a space.
                    if (plantname[i] == ' ')
                    {
                        s += '-';
                    }
                    else
                    {
                        s += plantname[i];
                    }
                }
                plantname = s;
            }

            catch (System.NullReferenceException)
            {
                return StatusCode(500);
            }

            using (HttpClient client = new HttpClient())
            {
                var plants = new List<Plant>();
                List<dynamic> dynamicPlant = new List<dynamic>();
                var response = await client.GetAsync($"http://growstuff.org/crops/{plantname}.json");
                var jsonDataAsString = await response.Content.ReadAsStringAsync();
                dynamic config = JsonConvert.DeserializeObject<ExpandoObject>(jsonDataAsString, new ExpandoObjectConverter());
                Plant newPlant = new Plant(config);
                plants.Add(newPlant);
                var searchedPlants = new OkObjectResult(plants);
                return (searchedPlants);


            }
        }
        [HttpGet("{singleplantname}")]
        [Route("singleplantname")]
        public async Task<IActionResult> GetSinglePlantByName([FromQuery] string plantname)
        {
            String s = "";

            try
            {
                plantname = plantname.ToLower();
                for (int i = 0; i < plantname.Length; ++i)
                {

                    // Changing the ith character
                    // to '-' if it's a space.
                    if (plantname[i] == ' ')
                    {
                        s += '-';
                    }
                    else
                    {
                        s += plantname[i];
                    }
                }
                plantname = s;
            }

            catch (System.NullReferenceException)
            {
                return StatusCode(500);
            }

            using (HttpClient client = new HttpClient())
            {
                //var plants = new List<Plant>();
                List<dynamic> dynamicPlant = new List<dynamic>();
                var response = await client.GetAsync($"http://growstuff.org/crops/{plantname}.json");
                var jsonDataAsString = await response.Content.ReadAsStringAsync();
                dynamic config = JsonConvert.DeserializeObject<ExpandoObject>(jsonDataAsString, new ExpandoObjectConverter());
                Plant newPlant = new Plant(config);
                //plants.Add(newPlant);
                var searchedPlants = new OkObjectResult(newPlant);
                return (searchedPlants);


            }
        }

        [HttpGet]
        [Route("plantlist")]
        public async Task<IActionResult> ViewCrops()
        {
            using (HttpClient client = new HttpClient())
            {
                var plants = new List<Plant>();
                List<dynamic> dynamicPlant = new List<dynamic>();
                List<Task<HttpResponseMessage>> responseTaskList = new List<Task<HttpResponseMessage>>();

                for (var x = 1; x < 50;  x++)
                {
                    var response =  client.GetAsync(string.Format(plantURL, $"/{x}"));
                    responseTaskList.Add(response);
                    //var jsonDataAsString = await response.Content.ReadAsStringAsync();
                    //var plant = JsonConvert.DeserializeObject<Plant>(jsonDataAsString);

                    //plants.Add(plant);

                    //int status = (int)response.StatusCode;
                    //if (status != 404)
                    //{
                    //    var jsonDataAsString = await response.Content.ReadAsStringAsync();
                    //    dynamic config = JsonConvert.DeserializeObject<ExpandoObject>(jsonDataAsString, new ExpandoObjectConverter());
                        

                    //    Plant newPlant = new Plant(config);
                    //    plants.Add(newPlant);
                    //    //dynamicPlant.Add(config);
                    //}
                    
                }

                var taskList = await Task.WhenAll(responseTaskList);

                for (int i = 0; i < taskList.Length; i++)
                {
                    int status = (int)taskList[i].StatusCode;
                    if (status != 404)
                    {
                        var jsonDataAsString = await taskList[i].Content.ReadAsStringAsync();
                        dynamic config = JsonConvert.DeserializeObject<ExpandoObject>(jsonDataAsString, new ExpandoObjectConverter());


                        Plant newPlant = new Plant(config);
                        plants.Add(newPlant);
                        //dynamicPlant.Add(config);
                    }
                }
                //var listOfPlants = new OkObjectResult (plants);
                List<Plant> cacheEntry;
                if (!_cache.TryGetValue(CacheKeys.Entry, out cacheEntry))
                {
                    // Key not in cache, so get data.
                    cacheEntry = plants;

                    // Set cache options.
                    var cacheEntryOptions = new MemoryCacheEntryOptions()
                        // Keep in cache for this time, reset time if accessed.
                        .SetSlidingExpiration(TimeSpan.FromSeconds(600));

                    // Save data in cache.
                    _cache.Set(CacheKeys.Entry, cacheEntry, cacheEntryOptions);
                }
                var listOfPlants = new OkObjectResult(plants);


                return (listOfPlants);
            }

        }
    }
}
