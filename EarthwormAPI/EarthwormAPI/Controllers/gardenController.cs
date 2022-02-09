using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EarthwormAPI.Data;
using EarthwormAPI.Models;

namespace EarthwormAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class gardenController : ControllerBase
    {
        private readonly EarthwormAPIContext _context;

        public gardenController(EarthwormAPIContext context)
        {
            _context = context;
        }

        [HttpGet("{gardenname}/{username}")]
        [Route("getgarden")]
        public async Task<ActionResult<garden>> GetGarden([FromQuery] string gardenname, [FromQuery] string username)
        {
            var gardens = await _context.garden.ToListAsync();
            var joinedGardens = new List<string>();

            foreach (garden g in gardens)
            {
                if (g.gardenName == gardenname && g.username == username)
                {
                    joinedGardens.Add(g.plantName);
                }
            }

            var result = new OkObjectResult(joinedGardens);

            return result;
        }

        [HttpGet]
        [Route("viewgardens")]
        public async Task<IActionResult> ViewGardens(string userinput)
        {
            var userGardens = new List<string>();
            var gardens = await _context.garden.ToListAsync();
            var userGardensCompare = new List<string>();

            foreach (garden g in gardens)
            {
                if (g.username == userinput)
                {
                    userGardens.Add(g.gardenName);
                    userGardensCompare.Add(g.gardenName);
                }
            }

            var userGardensSuccinct = userGardens.Intersect(userGardensCompare);

            var result = new OkObjectResult(userGardensSuccinct);

            return result;
        }

        [HttpPost]
        [Route("addgarden")]
        public async Task<IActionResult> AddGarden([Bind("gardenName,plantName,username")] garden garden)
        {
            garden.gardenName.ToLower();
            garden.username.ToLower();

            await _context.AddAsync(garden);
            await _context.SaveChangesAsync();

            var result = new OkObjectResult(garden);
            return result;

        }

        [HttpPut]
        [Route("deletegarden")]
        public async Task<ActionResult<garden>> DeleteGarden(string gardenName, [Bind("gardenName, username")] gardenCRUD gardenDelete)
        {
            gardenDelete.gardenName.ToLower();
            gardenDelete.username.ToLower();

            var gardens = await _context.garden.ToListAsync();
            foreach (garden g in gardens)
            {
                if (g.gardenName == gardenName & g.username == gardenDelete.username)
                {
                    _context.garden.Remove(g);
                }
            }

            await _context.SaveChangesAsync();

            var result = new OkObjectResult(await _context.garden.ToListAsync());

            return result;
        }

        [HttpPatch]
        [Route("updategarden")]
        public async Task<IActionResult> UpdateGarden(string gardenName, [Bind("gardenName, username")] gardenCRUD gardenUpdate)
        {
            gardenUpdate.gardenName.ToLower();

            var gardens = await _context.garden.ToListAsync();
            foreach (garden g in gardens)
            {
                if (g.gardenName == gardenName & g.username == gardenUpdate.username)
                {
                    g.gardenName = gardenUpdate.gardenName;
                }
            }

            await _context.SaveChangesAsync();

            var result = new OkObjectResult(await _context.garden.ToListAsync());

            return result;
        }

        [HttpPatch("{gardenname}/{plantname}")]
        [Route("deleteplant")]
        public async Task<IActionResult> DeletePlant([FromQuery]string gardenName, [FromQuery]string plantName, [Bind("gardenName, username")] gardenCRUD gardenPlantDelete)
        {
            gardenName.ToLower();
            gardenPlantDelete.username.ToLower();
            int gardenID = 0;

            var gardens = await _context.garden.ToListAsync();

            foreach (garden g in gardens)
            {
                if (g.gardenName == gardenName && g.username == gardenPlantDelete.username && g.plantName == plantName)
                {
                    gardenID = g.id;
                    
                }
            }

            var deletePlant = await _context.garden.FirstOrDefaultAsync(m => m.id == gardenID);

            _context.Remove(deletePlant);

            await _context.SaveChangesAsync();

            var result = new OkObjectResult(await _context.garden.ToListAsync());

            return result;
        }
    }
}
