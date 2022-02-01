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
        [Route("ViewGardens")]
        public async Task<IActionResult> ViewGardens(string userinput)
        {
            //var userinput = "";
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
        [HttpGet("getgarden")]
        public async Task<ActionResult<garden>> Getgarden(string name)
        {
            var gardens = await _context.garden.ToListAsync();
            var joinedGardens = new List<string>();

           foreach (garden g in gardens)
            {
                if(g.gardenName == name)
                {
                    joinedGardens.Add(g.plantName);
                }
            }

            var result = new OkObjectResult(joinedGardens);

            return result;
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
