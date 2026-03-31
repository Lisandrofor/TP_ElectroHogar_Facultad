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

public void GuardarVentasMock(List<Venta> ventas)
{
    try
    {
        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Ventas.json");

        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        string json = JsonSerializer.Serialize(ventas, options);

        File.WriteAllText(path, json);
    }
    catch (Exception ex)
    {
        throw new Exception("Error al guardar ventas: " + ex.Message);
    }
}


public void BorrarVenta(Guid idVenta)
{
    string path = "Ventas.json";

    string json = File.ReadAllText(path);
    List<Venta> lista = JsonConvert.DeserializeObject<List<Venta>>(json);

    Venta ventaAEliminar = lista.Find(p => p.Id == idVenta);

    if (ventaAEliminar != null)
    {
        lista.Remove(ventaAEliminar);

        string nuevoJson = JsonConvert.SerializeObject(lista, Formatting.Indented);
        File.WriteAllText(path, nuevoJson);
    }
}