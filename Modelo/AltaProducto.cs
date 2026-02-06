using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class AltaProducto
    {

        int _idCategoria;
        string _idUsuario;
        string _idProveedor;
        string _nombre;
        decimal _precio;
        int _stock;
        decimal _impuesto;
        int _cantidad;
        decimal _subtotal;

        public AltaProducto(int categoria, string idUsuario, string idProveedor, string nombre, decimal precio, int stock )
        {
            _idCategoria = categoria;
            _idUsuario = idUsuario;
            _idProveedor = idProveedor;
            _nombre = nombre;
            _precio = precio;
            _stock = stock;
        }
        public AltaProducto(int categoria, string idUsuario, string idProveedor, string nombre, decimal precio, int stock, decimal impuesto)
        {
            _idCategoria = categoria;
            _idUsuario = idUsuario;
            _idProveedor = idProveedor;
            _nombre = nombre;
            _precio = precio;
            _stock = stock;
            _impuesto = impuesto;
        }
        public AltaProducto() 
        { 
        }



        public int idCategoria { get => _idCategoria; set => _idCategoria = value; }
        public string idUsuario { get => _idUsuario; set => _idUsuario = value; }

        public string idProveedor { get=>_idProveedor; set=> _idProveedor=value; }
        public string  nombre { get=>_nombre; set=>_nombre=value; }

        public decimal precio { get=>_precio; set=>_precio=value; }

        public int stock { get => _stock; set => _stock=value; }

        public decimal impuesto { get => _impuesto; set => _impuesto = value; }

        public int cantidad { get => _cantidad; set => _cantidad = value; }

        public decimal Subtotal => precio * cantidad;

        public decimal TotalImpuesto => (Subtotal * impuesto) / 100;


    }
}
