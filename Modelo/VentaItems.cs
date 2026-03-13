using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{

public class VentaItems : INotifyPropertyChanged
    {
        
            public event PropertyChangedEventHandler PropertyChanged;

            public Producto Producto { get; set; }

            private int _cantidad;
            public int Cantidad
            {
                get => _cantidad;
                set
                {
                    _cantidad = value;
                    OnPropertyChanged(nameof(Cantidad));
                    OnPropertyChanged(nameof(Subtotal));
                    OnPropertyChanged(nameof(ImpuestoCalculado));
                    OnPropertyChanged(nameof(Total));
                }
            }

        
       

        public decimal Precio { get; set; }
            public decimal Descuento { get; set; }

            public int IdImpuesto
            {
                get => Producto.IdImpuesto;
                set => Producto.IdImpuesto = value;
            }

            public Impuesto Impue
            {
                get => Producto.impuesto;
                set
                {
                    Producto.impuesto = value;
                    OnPropertyChanged(nameof(Impue));
                    OnPropertyChanged(nameof(ImpuestoCalculado));
                    OnPropertyChanged(nameof(Total));
                }
            }


        public VentaItems(Producto producto, int cantidad, decimal precio, Impuesto imp) 
        { Producto = producto; Cantidad = cantidad; Precio = precio; Impue = imp; }
        public string NombreProducto => Producto.nombre;
        public decimal Subtotal
                => (Precio * Cantidad) - Descuento;

            public decimal ImpuestoCalculado
                => Subtotal * (Impue?.Porcentaje ?? 0);

            public decimal Total
                => Subtotal + ImpuestoCalculado;

            protected void OnPropertyChanged(string propiedad)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propiedad));
            }
        }


    }







