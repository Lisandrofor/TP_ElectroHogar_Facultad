using System.IO;
using System.Text.Json;

public List<Usuario> ObtenerUsuariosMock()
{
    string path = "usuarios.json";

    if (!File.Exists(path))
        return new List<Usuario>();

    string json = File.ReadAllText(path);

    var usuarios = JsonSerializer.Deserialize<List<Usuario>>(json);

    return usuarios ?? new List<Usuario>();
}

using System.IO;
using System.Text.Json;

public void GuardarProductosMock(List<Producto> productos)
{
    string path = "productos.json";

    var json = JsonSerializer.Serialize(productos, new JsonSerializerOptions
    {
        WriteIndented = true // para que el JSON quede legible
    });

    File.WriteAllText(path, json);
}