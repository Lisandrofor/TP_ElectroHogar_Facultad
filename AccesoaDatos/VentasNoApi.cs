using System.IO;
using System.Text.Json;

public List<Venta> ObteneVentasMock ()
{
    string path = "Ventas.json";

    if (!File.Exists(path))
        return new List<Venta>();

    string json = File.ReadAllText(path);

    var Ventas = JsonSerializer.Deserialize<List<Venta>>(json);

    return Ventas ?? new List<Venta>();
}

public void GuardarVentasMock(List<Producto> productos)
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


public void BorrarProducto(Guid idProducto)
{
    string path = "Productos.json";

    string json = File.ReadAllText(path);
    List<Producto> lista = JsonConvert.DeserializeObject<List<Producto>>(json);

    Producto productoAEliminar = lista.Find(p => p.Id == idProducto);

    if (productoAEliminar != null)
    {
        lista.Remove(productoAEliminar);

        string nuevoJson = JsonConvert.SerializeObject(lista, Formatting.Indented);
        File.WriteAllText(path, nuevoJson);
    }
}