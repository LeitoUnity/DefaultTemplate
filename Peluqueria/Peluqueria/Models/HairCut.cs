using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peluqueria.Models
{
    public class HairCut
    {
        public int ID { get; set; }

        public int BarbershopID { get; set; }
        
        public double Price { get; set; }

        public string Name { get; set; }
    }
}
