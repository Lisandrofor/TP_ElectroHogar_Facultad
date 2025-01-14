using AccesoaDatos.Utilidades;
using Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AccesoaDatos
{
    public class ProductosDatos
    {
       
        public List<Producto> getProductos()
        {
            string path = "/api/Producto/TraerProductos";
            List<Producto> Productos = new List<Producto>();
            try
            {
                HttpResponseMessage response = WebHelper.Get(path);
                if (response.IsSuccessStatusCode)
                {
                    var contentStream = response.Content.ReadAsStringAsync().Result;
                    List<Producto> listadoProductos = JsonConvert.DeserializeObject<List<Producto>>(contentStream);
                    return listadoProductos;
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
            return Productos;

        }

        public List<Producto> getProductosporCat(int idcategoria)
        {
            
            
            string path = "/api/Producto/TraerProductosPorCategoria?catnum="+idcategoria;
            List<Producto> Productos = new List<Producto>();
            try
            {
                HttpResponseMessage response = WebHelper.Get(path);
                if (response.IsSuccessStatusCode)
                {
                    var contentStream = response.Content.ReadAsStringAsync().Result;
                    List<Producto> listadoProductos = JsonConvert.DeserializeObject<List<Producto>>(contentStream);
                    return listadoProductos;
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
            return Productos;

        }



        public void ModificarProducto(Guid id,Guid idUsuario,float precio,int stock)
        {
            string path = "/api/Producto/ModificarProducto";
            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("id", id.ToString());
            map.Add("idUsuario", idUsuario.ToString());
            map.Add("precio", precio.ToString());
            map.Add("stock", stock.ToString());

            var jsonRequest = JsonConvert.SerializeObject(map);

            try
            {
                HttpResponseMessage response = WebHelper.Patch(path, jsonRequest);
                if (response.IsSuccessStatusCode)
                {
                    var reader = new StreamReader(response.Content.ReadAsStreamAsync().Result);
                    string respuesta = reader.ReadToEnd();
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }

        



       







        public void AgregarProd(AltaProducto altaProd)
        {
            string path = "/api/Producto/AgregarProducto";

            var jsonRequest = JsonConvert.SerializeObject(altaProd);


            try
            {
                HttpResponseMessage response = WebHelper.Post(path, jsonRequest);
                if (response.IsSuccessStatusCode)
                {
                    var reader = new StreamReader(response.Content.ReadAsStreamAsync().Result);
                    string respuesta = reader.ReadToEnd();
                }
                else
                {
                    var reader = new StreamReader(response.Content.ReadAsStreamAsync().Result);
                    string respuesta = reader.ReadToEnd();
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }

        public void BorrarProducto()
        {
            string path = "/api/Producto/BajaProducto";

            try
            {
                HttpResponseMessage response = WebHelper.DeleteConBody(path);
                if (response.IsSuccessStatusCode)
                {
                    var reader = new StreamReader(response.Content.ReadAsStreamAsync().Result);
                    string respuesta = reader.ReadToEnd();
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }
    }
}
