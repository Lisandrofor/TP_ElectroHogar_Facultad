using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Venta
    {
        Guid _id;
        string _idUsuario;
        string _idCliente;
        string _idProducto;
        int _cantidad;
        DateTime _fechaAlta;
        EstadoVenta _estado;


        public Venta()
        {

        }
        public Venta(Guid id, string idUsuario, string idCliente, string idProducto, int cantidad, DateTime fechaAlta, EstadoVenta estado)
        {
            _id=id;
            _idUsuario=idUsuario;
            _idCliente=idCliente;
            _idProducto=idProducto;
            _cantidad=cantidad;
            _fechaAlta=fechaAlta;
            _estado=estado;


        }

        public  enum EstadoVenta
        {
            EnProceso,
            Finalizada
        }

        public Guid id { get=>_id; set=>_id=value; }
        public string idUsuario { get=>_idUsuario; set=>_idUsuario=value; }
        public string idCliente { get=>_idCliente; set=>_idCliente=value; }    
        public string idProducto { get=>_idProducto; set=>_idProducto=value; }
        public int cantidad { get=>_cantidad; set=>_cantidad=value; }
        
        public DateTime fechaAlta { get=>_fechaAlta; set=>_fechaAlta=value; }
        

        public EstadoVenta estado { get => _estado; set => _estado = value; }






    }
}
