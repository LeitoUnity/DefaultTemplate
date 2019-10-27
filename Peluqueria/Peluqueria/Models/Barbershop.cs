using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peluqueria.Models
{
    public class Barbershop
    {

        public int ID { get; set; }

        public string Name { get; set; }
        
        public string Street { get; set; }

        public string Number { get; set; }

        public double Balance { get; set; }

        public ICollection<HairCut> HairCuts { get; set; }
        
        public ICollection<Client> Clients { get; set; }
    }
}
