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
        float _precio;
        int _stock;
    
    public AltaProducto(int categoria, string idUsuario, string idProveedor, string nombre, float precio, int stock )
        {
            _idCategoria = categoria;
            _idUsuario = idUsuario;
            _idProveedor = idProveedor;
            _nombre = nombre;
            _precio = precio;
            _stock = stock;
        }

        public int idCategoria { get => _idCategoria; set => _idCategoria = value; }
        public string idUsuario { get => _idUsuario; set => _idUsuario = value; }

        public string idProveedor { get=>_idProveedor; set=> _idProveedor=value; }
        public string  nombre { get=>_nombre; set=>_nombre=value; }

        public float precio { get=>_precio; set=>_precio=value; }

        public int stock { get => _stock; set => _stock=value; }
    }
}
