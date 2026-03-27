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

public void GuardarUsuariosMock(List<Usuario> Usuarios)
{
    string path = "Usuario.json";

    var json = JsonSerializer.Serialize(Usuarios, new JsonSerializerOptions
    {
        WriteIndented = true // para que el JSON quede legible
    });

    File.WriteAllText(path, json);
}




public List<Loginuser> ObtenerUsuariosLogueadosMock()
{
    string path = "usuarios.json";

    if (!File.Exists(path))
        return new List<Loginuser>();

    string json = File.ReadAllText(path);

    var usuarios = JsonSerializer.Deserialize<List<Loginuser>>(json);

    return usuarios ?? new List<Loginuser>();
}