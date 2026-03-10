using System;
using System.Collections.Generic;
using System.ComponentModel;
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

public  enum EstadoVenta
        {
            Pendiente,
            Pagada,
            Cancelada
        }


        public Venta()
        {
          fechaAlta = DateTime.Now;
          estado = EstadoVenta.Pendiente;
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


public Venta(string idUsuario, string idCliente, BindingList<VentaItems> items)
{
    _id = Guid.NewGuid();
    _idUsuario = idUsuario;
    _idCliente = idCliente;
    _fechaAlta = DateTime.Now;
    _estado = EstadoVenta.Pendiente;

    this.items = items ?? new BindingList<VentaItems>();
}

        

        public Guid id { get=>_id; set=>_id=value; }
        public string idUsuario { get=>_idUsuario; set=>_idUsuario=value; }
        public string idCliente { get=>_idCliente; set=>_idCliente=value; }    
        public string idProducto { get=>_idProducto; set=>_idProducto=value; }
        public int cantidad { get=>_cantidad; set=>_cantidad=value; }
        
        public DateTime fechaAlta { get=>_fechaAlta; set=>_fechaAlta=value; }
        

        public EstadoVenta estado { get => _estado; set => _estado = value; }




        //public IReadOnlyCollection<VentaItems> items => _items.AsReadOnly();


        private BindingList<VentaItems> items = new BindingList<VentaItems>();

        public BindingList<VentaItems> Items
        {
            get { return items; }
        }





        public void AgregarItem(VentaItems item)
    {
        _items.Add(item);
    }
    public void QuitarItem(VentaItems item)
    {
            _items.Remove(item);
    }

        public decimal Subtotal()
    {
        return _items.Sum(i => i.Subtotal);
    }

    public decimal TotalImpuestos()
    {
        return _items.Sum(i => i.ImpuestoCalculado);
    }

    public decimal Total()
    {
        return Subtotal() + TotalImpuestos();
    }

    public void MarcarComoPagada()
    {
        estado = EstadoVenta.Pagada;
    }

    public void Cancelar()
    {
        estado = EstadoVenta.Cancelada;
    }

        

       


    }
}
