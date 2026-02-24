using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Modelo
{
    public class Producto: INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    
        Guid _id;
        int _idcategoria;
        string _nombre;
        DateTime _fechaAlta;
        DateTime? _fechaBaja;
        decimal _precio;
        int _stock;
        string _nomCategoria;
        int _cantidad;
        float _descuento;
        Impuesto _impuesto;

        


        public Producto()
        {

        }




        public Producto(int idcategoria, string nomCategoria)
        {
            _idcategoria = idcategoria;
            _nomCategoria = nomCategoria;

        }

        public Producto(string nombre, int cantidad)
        {
            _nombre = nombre;
            _cantidad = cantidad;

        }


        






        public Producto(Guid id, int idcategoria, string nombre, DateTime fechaAlta, DateTime fechaBaja, decimal precio, int stock)
        {
            _id = id;
            _idcategoria = idcategoria;
            _nombre = nombre;
            _fechaAlta = fechaAlta;
            _fechaBaja = fechaBaja;
            _precio = precio;
            _stock = stock;





        }








        public Guid id { get => _id; set => _id = value; }
        public int idCategoria { get => _idcategoria; set => _idcategoria = value; }

        public string nombre { get => _nombre; set => _nombre = value; }
        public DateTime fechaAlta { get => _fechaAlta; set => _fechaAlta = value; }
        public DateTime? fechaBaja { get => _fechaBaja; set => _fechaBaja = value; }
        
        public int stock { get => _stock; set => _stock = value; }


        



        public decimal SubTotal => precio * cantidad;

        public float descuento { get => _descuento; set => _descuento = value; }

    

        

        [Browsable(false)]
       

        public string nomCategoria { get => _nomCategoria; set => _nomCategoria = value; }


        public int IdImpuesto
        {
            get => impuesto?.Id ?? 0;
            set
            {
                impuesto = new Impuesto { Id = value };
                OnPropertyChanged(nameof(IdImpuesto));
                OnPropertyChanged(nameof(Total));
            }
        }
public decimal Precio
    {
        get => _precio;
        set
        {
            _precio = value;
            OnPropertyChanged(nameof(Precio));
            OnPropertyChanged(nameof(Subtotal));
            OnPropertyChanged(nameof(Total));
        }
    }

    public int Cantidad
    {
        get => _cantidad;
        set
        {
            _cantidad = value;
            OnPropertyChanged(nameof(Cantidad));
            OnPropertyChanged(nameof(Subtotal));
            OnPropertyChanged(nameof(Total));
        }
    }

    public Impuesto impuesto
    {
        get => _impuesto;
        set
        {
            _impuesto = value;
            OnPropertyChanged(nameof(impuesto));
            OnPropertyChanged(nameof(IdImpuesto));
            OnPropertyChanged(nameof(Total));
        }
    }

 

    public decimal Subtotal => Precio * Cantidad;

    public decimal Total =>
        impuesto == null
            ? Subtotal
            : Subtotal + (Subtotal * impuesto.Porcentaje);

    protected void OnPropertyChanged(string propiedad)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propiedad));
    }


        public override string ToString()
        {
            return $"{idCategoria}-{nomCategoria}";
        }

        //public float Totalprodu(int cantidad,float precio)
        //{

        //    return cantidad*precio;
        //}
       

       






    }
}