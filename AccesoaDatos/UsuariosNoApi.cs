using System.IO;
using System.Text.Json;

public List<Loginuser> ObtenerUsuariosMock()
{
    string path = "usuarios.json";

    if (!File.Exists(path))
        return new List<Loginuser>();

    string json = File.ReadAllText(path);

    var usuarios = JsonSerializer.Deserialize<List<Loginuser>>(json);

    return usuarios ?? new List<Loginuser>();
}