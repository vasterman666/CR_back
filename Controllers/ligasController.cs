using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CR_back.Models;

namespace CR_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ligasController : ControllerBase
    {
        private readonly CountryContext _context;

        public ligasController(CountryContext context)
        {
            _context = context;
        }

        // GET: api/ligas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<liga>>> Getliga()
        {
            return await _context.liga.ToListAsync();
        }

        // GET: api/ligas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<liga>> Getliga(int id)
        {
            var liga = await _context.liga.FindAsync(id);

            if (liga == null)
            {
                return NotFound();
            }

            return liga;
        }

        // PUT: api/ligas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putliga(int id, liga liga)
        {
            if (id != liga.ligaID)
            {
                return BadRequest();
            }

            _context.Entry(liga).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ligaExists(id))
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

        // POST: api/ligas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<liga>> Postliga(liga liga)
        {
            _context.liga.Add(liga);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getliga", new { id = liga.ligaID }, liga);
        }

        // DELETE: api/ligas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<liga>> Deleteliga(int id)
        {
            var liga = await _context.liga.FindAsync(id);
            if (liga == null)
            {
                return NotFound();
            }

            _context.liga.Remove(liga);
            await _context.SaveChangesAsync();

            return liga;
        }

        private bool ligaExists(int id)
        {
            return _context.liga.Any(e => e.ligaID == id);
        }
    }
}
