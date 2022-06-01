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
    public class teamsController : ControllerBase
    {
        private readonly CountryContext _context;

        public teamsController(CountryContext context)
        {
            _context = context;
        }

        // GET: api/teams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<team>>> Getteam()
        {
            return await _context.team.ToListAsync();
        }

        // GET: api/teams/5


        [HttpGet("nameteam/{nt}")]
        public async Task<ActionResult<team>> GetNameTeam(string nt)
        {
            var cos = from team in _context.team where team.teamname == nt select team;

            if (nt == null)
            {
                return NotFound();
            }

            return Ok(cos);
        }

        [HttpGet("cost/{c}")]
        public async Task<ActionResult<team>> Getcost(int c)
        {
            var cos = from team in _context.team where team.cost > c select team;

            if (cos == null)
            {
                return NotFound();
            }
            
            return Ok(cos);
        }

        [HttpGet("{id}")]
        
        public async Task<ActionResult<team>> Getteam(int id)
        {
            var team = await _context.team.FindAsync(id);

            if (team == null)
            {
                return NotFound();
            }

            return team;
        }

        // PUT: api/teams/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putteam(int id, team team)
        {
            if (id != team.teamID)
            {
                return BadRequest();
            }

            _context.Entry(team).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!teamExists(id))
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

        // POST: api/teams
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<team>> Postteam(team team)
        {
            _context.team.Add(team);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getteam", new { id = team.teamID }, team);
        }

        // DELETE: api/teams/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<team>> Deleteteam(int id)
        {
            var team = await _context.team.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }

            _context.team.Remove(team);
            await _context.SaveChangesAsync();

            return team;
        }

        private bool teamExists(int id)
        {
            return _context.team.Any(e => e.teamID == id);
        }
    }
}
