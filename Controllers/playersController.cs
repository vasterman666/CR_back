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
    public class playersController : ControllerBase
    {
        private readonly CountryContext _context;

        public playersController(CountryContext context)
        {
            _context = context;
        }

        // GET: api/players
        [HttpGet]
        public async Task<ActionResult<IEnumerable<player>>> Getplayer()
        {
            return await _context.player.ToListAsync();
        }

        // GET: api/players/5
        [HttpGet("{id}")]
        public async Task<ActionResult<player>> Getplayer(int id)
        {
            var player = await _context.player.FindAsync(id);

            if (player == null)
            {
                return NotFound();
            }

            return player;
        }

        // PUT: api/players/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putplayer(int id, player player)
        {
            if (id != player.playerID)
            {
                return BadRequest();
            }

            _context.Entry(player).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!playerExists(id))
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

        // POST: api/players
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<player>> Postplayer(player player)
        {
            _context.player.Add(player);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getplayer", new { id = player.playerID }, player);
        }

        // DELETE: api/players/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<player>> Deleteplayer(int id)
        {
            var player = await _context.player.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }

            _context.player.Remove(player);
            await _context.SaveChangesAsync();

            return player;
        }

        private bool playerExists(int id)
        {
            return _context.player.Any(e => e.playerID == id);
        }
    }
}
