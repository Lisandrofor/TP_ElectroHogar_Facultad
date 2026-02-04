using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class GestordeImpuestos
    {
        public List<Impuesto> ObtenerImpuestos()
        {
            return new List<Impuesto>
        {
            new Impuesto { Id = 1, Nombre = "IVA 21%", Porcentaje = 0.21m },
            new Impuesto { Id = 2, Nombre = "IVA 10.5%", Porcentaje = 0.105m },
            new Impuesto { Id = 3, Nombre = "Exento", Porcentaje = 0m }
        };
        }


    }
}
