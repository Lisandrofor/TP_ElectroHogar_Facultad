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


            public Guid IdProducto { get; set; }
            public string Nombre { get; set; }

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
                get => IdImpuesto;
                set => IdImpuesto = value;
            }

            public Impuesto Impue
            {
                get => Impue;
                set
                {
                    Impue = value;
                    OnPropertyChanged(nameof(Impue));
                    OnPropertyChanged(nameof(ImpuestoCalculado));
                    OnPropertyChanged(nameof(Total));
                }
            }


        public VentaItems(Guid idProducto, string nombre, int cantidad, decimal precioUnitario, Impuesto imp) { IdProducto = idProducto; Nombre = nombre; Cantidad = cantidad; Precio = precioUnitario; Impue = imp; }

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







