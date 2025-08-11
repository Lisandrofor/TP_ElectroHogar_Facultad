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

        public void AgregarVenta(string idCliente,string idUsuario,string idProducto,int cantidad,DateTime fechaAlta,Venta.EstadoVenta estado)
        {


            Guid idVenta = Guid.NewGuid();


            Venta altaVenta = new Venta(idVenta,idCliente,idUsuario,idProducto,cantidad,fechaAlta,estado);

            try
            {
                VentasDa.AgregarVenta(altaVenta);



            }
            catch (Exception ex)
            {
                Console.WriteLine("Error general: " + ex.Message);
            }



        }

        

        public List<Venta> TraerVenta(string idVenta)
        {
            return VentasDa.GetVenta(idVenta);
        }

        public List<Venta> ObtenerVentas()
        {
            string rutaArchivo = "C:\\Users\\Usuario\\source\\repos\\TPCAI_Electro\\AccesoaDatos\\TextFile1.json";
            try
            {
                string jsonLeer = File.ReadAllText(rutaArchivo);
                List<Venta> listaCategorias = JsonConvert.DeserializeObject<List<Venta>>(jsonLeer);

                if (listaCategorias == null)
                {
                    listaCategorias = new List<Venta>(); // Retorna una lista vacía si el archivo estaba vacío o no se pudo deserializar
                }

                return listaCategorias;
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


        public void GuardarVentas(int idcategoria, string nomCategoria)
        {
            //Venta categoria = new Venta(idcategoria, nomCategoria);
            List<Venta> categorias;

            string rutaArchivo = "C:\\Users\\Usuario\\source\\repos\\TPCAI_Electro\\AccesoaDatos\\TextFile1.json";

            if (File.Exists(rutaArchivo))
            {
                // Deserializamos el contenido del archivo en una lista de objetos Producto
                string jsonArchivo = File.ReadAllText(rutaArchivo);
                try
                {
                    categorias = JsonConvert.DeserializeObject<List<Venta>>(jsonArchivo);
                }
                catch (JsonSerializationException)
                {
                    // Si falla, intentar deserializar como un solo objeto y convertirlo en una lista
                    //categoria = JsonConvert.DeserializeObject<Venta>(jsonArchivo);
                    //categorias = new List<Venta> { categoria };
                }


            }
            else
            {
                // Si el archivo no existe, inicializamos una nueva lista
                categorias = new List<Venta>();
            }

            // Agregamos la nueva categoría a la lista
            //categorias.Add(categoria);

            // Serializamos la lista completa de categorías y escribimos en el archivo
            //string nuevojson = JsonConvert.SerializeObject(categorias, Formatting.Indented);
            //File.WriteAllText(rutaArchivo, nuevojson);
        }

        


    }
}
