using AccesoaDatos;
using Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class GestordeVentas
    {
        private List<Venta> listaVentas = new List<Venta>();
        VentasDatos VentasDa = new VentasDatos();
        GestordeImpuestos gestor = new GestordeImpuestos();
        Venta venta = new Venta();
        public string _idCliente;

        public void AgregarVenta(string idCliente, string idUsuario, string idProducto, int cantidad, DateTime fechaAlta, Venta.EstadoVenta estado)
        {


            Guid id = Guid.NewGuid();


            Venta altaVenta = new Venta(id, idCliente, idUsuario, idProducto, cantidad, fechaAlta, estado);


            try
            {
                VentasDa.AgregarVenta(altaVenta);
                



            }
            catch (Exception ex)
            {
                Console.WriteLine("Error general: " + ex.Message);
            }



        }

        public bool ExisteVentaCliente(string idCliente)
        {
            return listaVentas.Any(v => v.idCliente == idCliente);
        }

        public void seleccionidCliente(string idCliente)
        {
            _idCliente = idCliente;
        }

        public decimal CalculaDescuento()
        {

            decimal total = venta.Subtotal;
            bool primeraCompra = !ExisteVentaCliente(_idCliente);

            if (total > 100000 || primeraCompra)
                total *= 0.90m; // 10% descuento

            return 0;
        }





        public List<Venta> ObtenerVentasporCliente(string idCliente)
        {
            return VentasDa.getVentasporCliente(idCliente);


        }



        public List<Venta> TraerVenta(string idVenta)
        {
            return VentasDa.GetVenta(idVenta);
        }





        public List<Venta> ObtenerVentasPorCliente(Guid idVenta)
        {
            string rutaArchivo = "C:\\Users\\vlisa\\source\\repos\\TP_ElectroHogar_Facultad\\AccesoaDatos\\Ventas.json";
            try
            {
                string jsonLeer = File.ReadAllText(rutaArchivo);
                List<Venta> listaVentas = JsonConvert.DeserializeObject<List<Venta>>(jsonLeer);

                if (listaVentas == null)
                {
                    listaVentas = new List<Venta>(); // Retorna una lista vacía si el archivo estaba vacío o no se pudo deserializar
                }

                return listaVentas;
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error al deserializar el archivo JSON: {ex.Message}");
                return new List<Venta>(); // Retorna una lista vacía en caso de error
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error al leer el archivo: {ex.Message}");
                return new List<Venta>(); // Retorna una lista vacía en caso de error
            }
        }


        public void GuardarVentas(Venta altaventa)
        {
            List<Venta> ventas;

            string rutaArchivo = "C:\\Users\\vlisa\\source\\repos\\TP_ElectroHogar_Facultad\\AccesoaDatos\\Ventas.json";

            if (File.Exists(rutaArchivo))
            {
                string jsonArchivo = File.ReadAllText(rutaArchivo);

                if (string.IsNullOrWhiteSpace(jsonArchivo))
                {
                    ventas = new List<Venta>();
                }
                else
                {
                    ventas = JsonConvert.DeserializeObject<List<Venta>>(jsonArchivo);
                }
            }
            else
            {
                ventas = new List<Venta>();
            }

            // 🔹 agregar la nueva venta
            ventas.Add(altaventa);

            // 🔹 convertir a json
            string nuevoJson = JsonConvert.SerializeObject(ventas, Formatting.Indented);

            // 🔹 guardar archivo
            File.WriteAllText(rutaArchivo, nuevoJson);





        }
    }
}
