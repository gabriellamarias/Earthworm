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

namespace EarthwormAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GrowStuffController : ControllerBase
    {
        public string plantURL = "https://www.growstuff.org/crops/{0}.json";
        public string baseURL = "https://www.growstuff.org/crops.json";
        [HttpGet]
        [Route("plantlist")]
        public async Task<IActionResult> ViewCrops()
        {
            using (HttpClient client = new HttpClient())
            {
                var plants = new List<Plant>();
                List<dynamic> dynamicPlant = new List<dynamic>();
                List<Task<HttpResponseMessage>> responseTaskList = new List<Task<HttpResponseMessage>>();

                for (var x = 1; x < 30;  x++)
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
                var listOfPlants = new OkObjectResult(plants);


                return (listOfPlants);
            }

        }
    }
}
