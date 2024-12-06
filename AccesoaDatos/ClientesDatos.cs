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
    public class ClientesDatos
    {

        private string idUsuario = "70b37dc1-8fde-4840-be47-9ababd0ee7e5";
        public List<Cliente> getCliente()
        {
            string path = "/api/Cliente/GetCliente?id=" + idUsuario;
            List<Cliente> Clientes = new List<Cliente>();
            try
            {
                HttpResponseMessage response = WebHelper.Get(path);
                if (response.IsSuccessStatusCode)
                {
                    var contentStream = response.Content.ReadAsStringAsync().Result;
                    List<Cliente> listadoClientes = JsonConvert.DeserializeObject<List<Cliente>>(contentStream);
                    return listadoClientes;
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
            return Clientes;

        }

        public void ModificarCliente(Guid idUsuario, string direccion, string telefono, string email)
        {
            string path = "/api/Cliente/ReactivarCliente?id="+idUsuario;
            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("id", idUsuario.ToString());
            map.Add("direccion", direccion);
            map.Add("telefono", telefono);
            map.Add("email", email);

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

        



       







        public void AgregarCliente(AltaCliente altacliente)
        {
            string path = "/api/Cliente/AgregarCliente";

            var jsonRequest = JsonConvert.SerializeObject(altacliente);


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

        public void BorrarCliente(Guid idUsuario)
        {
            string path = "/api/Cliente/BajaCliente?id=" + idUsuario;

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
