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
    public class gardenerController : ControllerBase
    {
        private readonly EarthwormAPIContext _context;

        public gardenerController(EarthwormAPIContext context)
        {
            _context = context;
        }

        // GET: api/gardener
        [HttpGet]
        public async Task<ActionResult<IEnumerable<gardener>>> Getgardener()
        {
            return await _context.gardener.ToListAsync();
        }

        // GET: api/gardener/5
        [HttpGet("{id}")]
        public async Task<ActionResult<gardener>> Getgardener(int id)
        {
            var gardener = await _context.gardener.FindAsync(id);

            if (gardener == null)
            {
                return NotFound();
            }

            return gardener;
        }

        // PUT: api/gardener/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putgardener(int id, gardener gardener)
        {
            if (id != gardener.id)
            {
                return BadRequest();
            }

            _context.Entry(gardener).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!gardenerExists(id))
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

        // POST: api/gardener
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<gardener>> Postgardener(gardener gardener)
        {
            _context.gardener.Add(gardener);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getgardener", new { id = gardener.id }, gardener);
        }

        // DELETE: api/gardener/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<gardener>> Deletegardener(int id)
        {
            var gardener = await _context.gardener.FindAsync(id);
            if (gardener == null)
            {
                return NotFound();
            }

            _context.gardener.Remove(gardener);
            await _context.SaveChangesAsync();

            return gardener;
        }

        private bool gardenerExists(int id)
        {
            return _context.gardener.Any(e => e.id == id);
        }
    }
}
