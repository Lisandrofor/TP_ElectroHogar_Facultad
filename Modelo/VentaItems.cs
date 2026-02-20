using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{

public class VentaItems
{
    public Producto Producto { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
    public decimal Descuento { get; set; } // descuento por item

    public VentaItems(Producto producto, int cantidad, decimal precioUnitario)
    {
        Producto = producto;
        Cantidad = cantidad;
        PrecioUnitario = precioUnitario;
    }

    public decimal Subtotal()
    {
        return (PrecioUnitario * Cantidad) - Descuento;
    }

    public decimal CalcularImpuesto()
    {
        return Subtotal() * Producto.impuesto.Porcentaje;
    }

    public decimal Total()
    {
        return Subtotal() + CalcularImpuesto();
    }

 }
}






