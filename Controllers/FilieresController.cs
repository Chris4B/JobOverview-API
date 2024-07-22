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
    public class FilieresController : ControllerBase
    {
        private readonly JobOverviewContext _context;

        public FilieresController(JobOverviewContext context)
        {
            _context = context;
        }

        // GET: api/Filieres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Filiere>>> GetFiliere()
        {
            return await _context.Filiere.ToListAsync();
        }

        // GET: api/Filieres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Filiere>> GetFiliere(string id)
        {
            var filiere = await _context.Filiere.FindAsync(id);

            if (filiere == null)
            {
                return NotFound();
            }

            return filiere;
        }

        // PUT: api/Filieres/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFiliere(string id, Filiere filiere)
        {
            if (id != filiere.CodeFiliere)
            {
                return BadRequest();
            }

            _context.Entry(filiere).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FiliereExists(id))
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

        // POST: api/Filieres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Filiere>> PostFiliere(Filiere filiere)
        {
            _context.Filiere.Add(filiere);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FiliereExists(filiere.CodeFiliere))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFiliere", new { id = filiere.CodeFiliere }, filiere);
        }

        // DELETE: api/Filieres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFiliere(string id)
        {
            var filiere = await _context.Filiere.FindAsync(id);
            if (filiere == null)
            {
                return NotFound();
            }

            _context.Filiere.Remove(filiere);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FiliereExists(string id)
        {
            return _context.Filiere.Any(e => e.CodeFiliere == id);
        }
    }
}
