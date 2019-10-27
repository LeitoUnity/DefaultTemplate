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
    public class ClientsController : ControllerBase
    {
        private readonly PeluqueriaContext db;

        public ClientsController(PeluqueriaContext _db)
        {
            db = _db;
        }

        // GET: api/Clients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClient()
        {
            return await db.Clients.ToListAsync();
        }

        // GET: api/Clients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            var client = await db.Clients.FindAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

        [HttpPost("{id}/GoToWork")]
        public async Task<ActionResult<Client>> GoToWork(int id)
        {
            if(!db.Clients.Any(i => i.ID == id))
            {
                return BadRequest();
            }

            var client = db.Clients.Find(id);

            client.Balance += 5000;

            await db.SaveChangesAsync();

            return Ok(client);
        }

        [HttpPost("{idUser}/GetHairCut/{idBarbershop}/{idHairCut}")]
        public async Task<ActionResult<Client>> GetHairCut(int idUser, int idBarbershop, int idHairCut)
        {
            if (!db.Barbershops.Any(i => i.ID == idBarbershop) || !db.HairCuts.Any(i => i.ID == idHairCut) || !db.Clients.Any(i => i.ID == idUser))
            {
                return BadRequest();
            }

            var client = db.Clients.Find(idUser);
            var hairCut = db.HairCuts.Find(idHairCut);
            var barbershop = db.Barbershops.Find(idBarbershop);

            client.Balance -= hairCut.Price;
            client.LastHairCut = hairCut;
            barbershop.Balance += hairCut.Price;

            await db.SaveChangesAsync();

            return Ok(client);
        }

        // PUT: api/Clients/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(int id, Client client)
        {
            if (id != client.ID)
            {
                return BadRequest();
            }

            db.Entry(client).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
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

        // POST: api/Clients
        [HttpPost]
        public async Task<ActionResult<Client>> PostClient(Client client)
        {
            db.Clients.Add(client);
            await db.SaveChangesAsync();

            return CreatedAtAction("GetClient", new { id = client.ID }, client);
        }

        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Client>> DeleteClient(int id)
        {
            var client = await db.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            db.Clients.Remove(client);
            await db.SaveChangesAsync();

            return client;
        }

        private bool ClientExists(int id)
        {
            return db.Clients.Any(e => e.ID == id);
        }
    }
}
