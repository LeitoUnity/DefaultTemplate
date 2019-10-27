using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Peluqueria.Data;
using Peluqueria.Models;

namespace Peluqueria.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class HairCutsController : ControllerBase
    {
        private readonly PeluqueriaContext _context;

        public HairCutsController(PeluqueriaContext context)
        {
            _context = context;
        }

        // GET: api/HairCuts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HairCut>>> GetHairCut()
        {
            return await _context.HairCuts.ToListAsync();
        }

        // GET: api/HairCuts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HairCut>> GetHairCut(int id)
        {
            var hairCut = await _context.HairCuts.FindAsync(id);

            if (hairCut == null)
            {
                return NotFound();
            }

            return hairCut;
        }

        // PUT: api/HairCuts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHairCut(int id, HairCut hairCut)
        {
            if (id != hairCut.ID)
            {
                return BadRequest();
            }

            _context.Entry(hairCut).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HairCutExists(id))
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

        // POST: api/HairCuts
        [HttpPost]
        public async Task<ActionResult<HairCut>> PostHairCut(HairCut hairCut)
        {
            _context.HairCuts.Add(hairCut);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHairCut", new { id = hairCut.ID }, hairCut);
        }

        // DELETE: api/HairCuts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HairCut>> DeleteHairCut(int id)
        {
            var hairCut = await _context.HairCuts.FindAsync(id);
            if (hairCut == null)
            {
                return NotFound();
            }

            _context.HairCuts.Remove(hairCut);
            await _context.SaveChangesAsync();

            return hairCut;
        }

        private bool HairCutExists(int id)
        {
            return _context.HairCuts.Any(e => e.ID == id);
        }
    }
}
