using System.IO;
using System.Text.Json;

public List<Producto> ObtenerProductosMock()
{
    string path = "productos.json";

    if (!File.Exists(path))
        return new List<Producto>();

    string json = File.ReadAllText(path);

    var productos = JsonSerializer.Deserialize<List<Producto>>(json);

    return productos ?? new List<Producto>();
}