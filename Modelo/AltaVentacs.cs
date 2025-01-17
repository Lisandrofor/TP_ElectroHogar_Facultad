using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class AltaVentacs
    {
        string _idCliente;
        string _idUsuario;
        string _idProducto;
        int _cantidad;
        float _subTotal;
        float _impuestos;
        float _descuento;
        float _total;


        public AltaVentacs(string idCliente,string idUsuario,string idProducto, int cantidad)
        {
            _idCliente = idCliente;
            _idUsuario = idUsuario;
            _idProducto = idProducto;
            _cantidad = cantidad;
        }

        public string idCliente { get=>_idCliente; set=>_idCliente=value; }
        public string idUsuario { get=>_idUsuario; set=>_idUsuario=value; }
        public string idProducto { get=>_idProducto; set=>_idProducto=value; }

        public int cantidad { get=>_cantidad; set=>_cantidad=value; }

        public float subTotal { get=>_subTotal; set=>_subTotal=value; }

        public float impuestos { get=>_impuestos; set=>_impuestos=value; }
        public float descuentos { get=>_descuento; set=>_descuento=value; }
        public float total { get=>_total; set=>_total=value; }

    }
}
