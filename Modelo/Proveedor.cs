using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Proveedor
    {
        Guid _idProveedor;
        Guid _idProducto;
        Guid _idUsuario;
        string _nombreProveedor;
        string _apellidoProveedor;
        Int64 _cuit;
        string _direccion;
        string _telefono;
        string _email;
        DateTime _fechaAlta;
        DateTime? _fechaBaja;
        
        EstadoProveedor _estadoProveed;


        public Proveedor()
        {
        }



        public Proveedor(Guid idProveedor,Guid idProducto,Guid idUsuario, string nombreProveedor, string apellidoProveedor, Int64 Cuit, EstadoProveedor EstadoProveed)
        {
            _idUsuario = idUsuario;
            _idProveedor = idProveedor;
            _nombreProveedor = nombreProveedor;
            _apellidoProveedor = apellidoProveedor;
            _cuit = Cuit;
            _idProducto = idProducto;
            
            _estadoProveed = EstadoProveed;

        }

        public Guid idProveedor { get => _idProveedor; set => _idProveedor = value; }
        public Guid idProducto { get => _idProducto; set => _idProducto = value; }
        public Guid idUsuario { get => _idUsuario; set => _idUsuario = value; }

        public string nombreProveedor { get => _nombreProveedor; set => _nombreProveedor = value; }
        public string apellidoProveedor { get => _apellidoProveedor; set => _apellidoProveedor = value; }
        public Int64 CUIT { get => _cuit; set => _cuit = value; }
        public string direccion { get => _direccion; set => _direccion = value; }
        public string telefono { get => _telefono; set => _telefono = value; }
        public string email { get => _email; set => _email = value; }
        
        
        public DateTime fechaAlta { get => _fechaAlta; set => _fechaAlta = value; }
        public DateTime? fechaBaja { get => _fechaBaja; set => _fechaBaja = value; }

        
        


        


        public enum EstadoProveedor
        {
            Activo,
            Inactivo
        }

        public EstadoProveedor Estado { get; set; }





        public override String ToString()
        {
            return this.nombreProveedor + ", " + this.apellidoProveedor + " (" + this.CUIT + ")";
        }


    }
}
