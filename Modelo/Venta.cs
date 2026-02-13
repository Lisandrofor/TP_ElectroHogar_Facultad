using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Venta
    {
        int _id;
        string _idUsuario;
        string _idCliente;
        string _idProducto;
        int _cantidad;
        DateTime _fechaAlta;
        EstadoVenta _estado;

public  enum EstadoVenta
        {
            Pendiente,
            Pagada,
            Cancelada
        }


        public Venta()
        {
          fechaAlta = DateTime.Now;
          EstadoVenta =
EstadoVenta.Pendiente;
        }
        public Venta(int id, string idUsuario, string idCliente, string idProducto, int cantidad, DateTime fechaAlta, EstadoVenta estado)
        {
            _id=id;
            _idUsuario=idUsuario;
            _idCliente=idCliente;
            _idProducto=idProducto;
            _cantidad=cantidad;
            _fechaAlta=fechaAlta;
            _estado=estado;


        }

        

        public int id { get=>_id; set=>_id=value; }
        public string idUsuario { get=>_idUsuario; set=>_idUsuario=value; }
        public string idCliente { get=>_idCliente; set=>_idCliente=value; }    
        public string idProducto { get=>_idProducto; set=>_idProducto=value; }
        public int cantidad { get=>_cantidad; set=>_cantidad=value; }
        
        public DateTime fechaAlta { get=>_fechaAlta; set=>_fechaAlta=value; }
        

        public EstadoVenta estado { get => _estado; set => _estado = value; }


private List<VentaItem> _items = new List<VentaItem>();

public IReadOnlyCollection<VentaItem> Items => _items.AsReadOnly();


public void AgregarItem(VentaItem item)
    {
        _items.Add(item);
    }

    public decimal Subtotal()
    {
        return _items.Sum(i => i.Subtotal());
    }

    public decimal TotalImpuestos()
    {
        return _items.Sum(i => i.CalcularImpuesto());
    }

    public decimal Total()
    {
        return Subtotal() + TotalImpuestos();
    }

    public void MarcarComoPagada()
    {
        Estado = EstadoVenta.Pagada;
    }

    public void Cancelar()
    {
        Estado = EstadoVenta.Cancelada;
    }


    }
}
