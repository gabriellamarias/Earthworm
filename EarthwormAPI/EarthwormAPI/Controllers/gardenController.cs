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

        // GET: api/garden
        [HttpGet]
        public async Task<ActionResult<IEnumerable<garden>>> Getgarden()
        {
            return await _context.garden.ToListAsync();
        }

        [HttpGet]
        [Route("ViewGarden")]
        public async Task<IActionResult> ViewGardens(string userinput)
        {
            //var userinput = "";
            var userGardens = new List<garden>();
            var gardens = await _context.garden.ToListAsync();
            foreach (garden g in gardens)
            {
                if (g.username == userinput)
                {
                    userGardens.Add(g);
                }
                

            }

            //var gardeners = await _context.gardener.ToListAsync();
            //var gardenUsername = new List<string>();
            //var gardenerGardens = new List<garden>();

            //foreach (gardener e in gardeners)
            //{
            //    gardenUsername.Add(e.username);
            //}
            //var gardenerUsername = gardens.Intersect(gardenUsername);

            //foreach (string username in gardenerUsername)
            //{
            //    var selectGarden = await _context.garden
            //.FirstOrDefaultAsync(m => m.EventID == id);
            //    favEvents.Add(selectEvent);
            //}

            var result = new OkObjectResult(userGardens);

            return result;

        }


        [HttpPost]
        
        public async Task<IActionResult> CreateGarden([Bind("gardenName,plantName")] garden garden)
        {

            
            await _context.AddAsync(garden);
            await _context.SaveChangesAsync();

            var result = new OkObjectResult(garden);
            return result;

        }

        [HttpDelete]
        public async Task<ActionResult<garden>> DeleteGarden(int id)
        {
            var garden = await _context.garden.FindAsync(id);
            if (garden == null)
            {
                return NotFound();
            }

            _context.garden.Remove(garden);
            await _context.SaveChangesAsync();

            return new OkResult();
        }

        // GET: api/garden/5
        [HttpGet("{id}")]
        public async Task<ActionResult<garden>> Getgarden(int id)
        {
            var garden = await _context.garden.FindAsync(id);

            if (garden == null)
            {
                return NotFound();
            }

            return garden;
        }

        // PUT: api/garden/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putgarden(int id, garden garden)
        {
            if (id != garden.id)
            {
                return BadRequest();
            }

            _context.Entry(garden).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!gardenExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/garden
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPost]
        //public async Task<ActionResult<garden>> Postgarden(garden garden)
        //{
        //    _context.garden.Add(garden);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("Getgarden", new { id = garden.id }, garden);
        //}

        // DELETE: api/garden/5
        //[HttpDelete("{id}")]
    

        private bool gardenExists(int id)
        {
            return _context.garden.Any(e => e.id == id);
        }
    }
}
