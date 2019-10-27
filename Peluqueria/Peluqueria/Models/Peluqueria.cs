using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peluqueria.Models
{
    public class Peluqueria

    {

        double CajaRegistradora;
        int PrecioCorteDePelo;
        int PrecioTintura;

        public ICollection<Client> Clients{get; set;}

    }
}
