using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peluqueria.Models
{
    public class Client
    {
        public int ID { get;set; }

        public int? BarbershopID { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public double Balance { get; set; }

        public int? HairCutID { get; set; } 

        public HairCut LastHairCut { get; set; }
    }
}
