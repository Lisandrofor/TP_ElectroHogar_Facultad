using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class VentaDTO
    {
        public string idUsuario { get; set; }
        public string idCliente { get; set; }
        public Venta.EstadoVenta estado { get; set; }
        public BindingList<VentaItems> items { get; set; }
        
    }
}
