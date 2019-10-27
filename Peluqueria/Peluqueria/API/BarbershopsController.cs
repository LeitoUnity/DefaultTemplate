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
    public class BarbershopsController : ControllerBase
    {
        private readonly PeluqueriaContext _context;

        public BarbershopsController(PeluqueriaContext context)
        {
            _context = context;
        }

        // GET: api/Barbershops
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Barbershop>>> GetBarbershop()
        {
            return await _context.Barbershops.ToListAsync();
        }

        // GET: api/Barbershops/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Barbershop>> GetBarbershop(int id)
        {
            var barbershop = await _context.Barbershops.FindAsync(id);

            if (barbershop == null)
            {
                return NotFound();
            }

            return barbershop;
        }

        // PUT: api/Barbershops/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBarbershop(int id, Barbershop barbershop)
        {
            if (id != barbershop.ID)
            {
                return BadRequest();
            }

            _context.Entry(barbershop).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BarbershopExists(id))
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

        // POST: api/Barbershops
        [HttpPost]
        public async Task<ActionResult<Barbershop>> PostBarbershop(Barbershop barbershop)
        {
            _context.Barbershops.Add(barbershop);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBarbershop", new { id = barbershop.ID }, barbershop);
        }

        // DELETE: api/Barbershops/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Barbershop>> DeleteBarbershop(int id)
        {
            var barbershop = await _context.Barbershops.FindAsync(id);
            if (barbershop == null)
            {
                return NotFound();
            }

            _context.Barbershops.Remove(barbershop);
            await _context.SaveChangesAsync();

            return barbershop;
        }

        private bool BarbershopExists(int id)
        {
            return _context.Barbershops.Any(e => e.ID == id);
        }
    }
}
