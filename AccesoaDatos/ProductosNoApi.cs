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

public void GuardarProductosMock(List<Producto> productos)
{
    try
    {
        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "productos.json");

        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        string json = JsonSerializer.Serialize(productos, options);

        File.WriteAllText(path, json);
    }
    catch (Exception ex)
    {
        throw new Exception("Error al guardar productos: " + ex.Message);
    }
}