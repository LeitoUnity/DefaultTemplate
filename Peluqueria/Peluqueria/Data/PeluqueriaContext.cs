using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Peluqueria.Models;

namespace Peluqueria.Data
{
    public class PeluqueriaContext : DbContext
    {
        public PeluqueriaContext (DbContextOptions<PeluqueriaContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
    }
}
