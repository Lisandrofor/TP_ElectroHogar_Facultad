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
    public class ProveedoresDatos
    {
        
        public List<Proveedor> getProveedores()
        {
            string path = "/api/Proveedor/TraerProveedores";
            List<Proveedor> Proveedores = new List<Proveedor>();
            try
            {
                HttpResponseMessage response = WebHelper.Get(path);
                if (response.IsSuccessStatusCode)
                {
                    var contentStream = response.Content.ReadAsStringAsync().Result;
                    List<Proveedor> listadoProveedor = JsonConvert.DeserializeObject<List<Proveedor>>(contentStream);
                    return listadoProveedor;
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
            return Proveedores;

        }

        public void ModificarProveedores(Guid idProveedor,Guid idUsuario)
        {
            string path = "/api/Proveedor/ReactivarProveedor";
            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("idProveedor", idProveedor.ToString());
            map.Add("idUsuario", idUsuario.ToString());

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

        


       







        public void AgregarProveedor(AltaProveedor altaproveedor)
        {
            string path ="/api/Proveedor/AgregarProveedor";

            var jsonRequest = JsonConvert.SerializeObject(altaproveedor);


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

        public void BorrarProveedor(Guid idProveedor,Guid idUsuario)
        {
            string path = "/api/Proveedor/BajaProveedor";

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
