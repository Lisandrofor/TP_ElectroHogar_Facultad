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
    public class VentasDatos
    {
        public List<Venta> getVentasporCliente(string idCliente)
        {
            string path = "/api/Venta/GetVentaByCliente?id="+ idCliente;
            List<Venta> VentasporClie = new List<Venta>();
            try
            {
                HttpResponseMessage response = WebHelper.Get(path);
                if (response.IsSuccessStatusCode)
                {
                    var contentStream = response.Content.ReadAsStringAsync().Result;
                    List<Venta> listadoVentaPorCLie = JsonConvert.DeserializeObject<List<Venta>>(contentStream);
                    return listadoVentaPorCLie;
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
            return VentasporClie;

        }

      



        public void ModificarProducto(Guid id, Guid idUsuario, float precio, int stock)
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













        public void AgregarVenta(Venta altaVenta)
        {
            string path = "/api/Venta/AgregarVenta";

            var jsonRequest = JsonConvert.SerializeObject(altaVenta);


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

        public List<Venta> GetVenta(string idVenta)
        {
            string path = "/api/Venta/GetVenta?id="+idVenta;

            List<Venta> ListaVentas = new List<Venta>();
            try
            {
                HttpResponseMessage response = WebHelper.Get(path);
                if (response.IsSuccessStatusCode)
                {
                    var contentStream = response.Content.ReadAsStringAsync().Result;
                    List<Venta> listadoVentas = JsonConvert.DeserializeObject<List<Venta>>(contentStream);
                    return listadoVentas;

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
            return ListaVentas;
        }







    }
}
