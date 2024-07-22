using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobOverview.Data;
using JobOverview.Model;

namespace JobOverview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogicielsController : ControllerBase
    {
        private readonly JobOverviewContext _context;

        public LogicielsController(JobOverviewContext context)
        {
            _context = context;
        }

        // GET: api/Logiciels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Logiciel>>> GetLogiciel()
        {
            return await _context.Logiciel.ToListAsync();
        }

        // GET: api/Logiciels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Logiciel>> GetLogiciel(string id)
        {
            var logiciel = await _context.Logiciel.FindAsync(id);

            if (logiciel == null)
            {
                return NotFound();
            }

            return logiciel;
        }

        // PUT: api/Logiciels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLogiciel(string id, Logiciel logiciel)
        {
            if (id != logiciel.CodeLogiciel)
            {
                return BadRequest();
            }

            _context.Entry(logiciel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LogicielExists(id))
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

        // POST: api/Logiciels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Logiciel>> PostLogiciel(Logiciel logiciel)
        {
            _context.Logiciel.Add(logiciel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LogicielExists(logiciel.CodeLogiciel))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLogiciel", new { id = logiciel.CodeLogiciel }, logiciel);
        }

        // DELETE: api/Logiciels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLogiciel(string id)
        {
            var logiciel = await _context.Logiciel.FindAsync(id);
            if (logiciel == null)
            {
                return NotFound();
            }

            _context.Logiciel.Remove(logiciel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LogicielExists(string id)
        {
            return _context.Logiciel.Any(e => e.CodeLogiciel == id);
        }
    }
}
