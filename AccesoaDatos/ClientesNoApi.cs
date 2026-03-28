using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;

namespace AccesoaDatos
{
    internal class ClientesNoApi
    {
        public List<Cliente> ObtenerClientesMock()
        {
            string path = "Clientes.json";

            if (!File.Exists(path))
                return new List<Cliente>();

            string json = File.ReadAllText(path);

            var clientes = JsonSerializer.Deserialize<List<Cliente>>(json);

            return clientes ?? new List<Cliente>();
        }

        public void GuardarClientesMock(List<Cliente> clientes)
        {
            string path = "Clientes.json";

            var json = JsonSerializer.Serialize(clientes, new JsonSerializerOptions
            {
                WriteIndented = true // para que el JSON quede legible
            });

            File.WriteAllText(path, json);
        }








        public void AgregarClienteMock(Cliente nuevoCliente)
        {
            string path = "Clientes.json";

            List<Cliente> clientes = new List<Cliente>();

            // 1. Leer si existe
            if (File.Exists(path))
            {
                string jsonExistente = File.ReadAllText(path);
                clientes = JsonSerializer.Deserialize<List<Cliente>>(jsonExistente)
                           ?? new List<Cliente>();
            }

            // 2. Agregar el nuevo
            clientes.Add(nuevoCliente);

            // 3. Guardar todo
            var json = JsonSerializer.Serialize(clientes, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(path, json);
        }


    }
}
