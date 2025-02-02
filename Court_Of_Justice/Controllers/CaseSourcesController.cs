using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Court_Of_Justice.Models;

namespace Court_Of_Justice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaseSourcesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CaseSourcesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CaseSources
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CaseSource>>> GetCaseSources()
        {
            return await _context.CaseSources.ToListAsync();
        }

        // GET: api/CaseSources/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CaseSource>> GetCaseSource(int id)
        {
            var caseSource = await _context.CaseSources.FindAsync(id);

            if (caseSource == null)
            {
                return NotFound();
            }

            return caseSource;
        }

        // PUT: api/CaseSources/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCaseSource(int id, CaseSource caseSource)
        {
            if (id != caseSource.ID)
            {
                return BadRequest();
            }

            _context.Entry(caseSource).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaseSourceExists(id))
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

        // POST: api/CaseSources
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CaseSource>> PostCaseSource(CaseSource caseSource)
        {
            _context.CaseSources.Add(caseSource);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCaseSource", new { id = caseSource.ID }, caseSource);
        }

        // DELETE: api/CaseSources/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCaseSource(int id)
        {
            var caseSource = await _context.CaseSources.FindAsync(id);
            if (caseSource == null)
            {
                return NotFound();
            }

            _context.CaseSources.Remove(caseSource);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CaseSourceExists(int id)
        {
            return _context.CaseSources.Any(e => e.ID == id);
        }
    }
}
