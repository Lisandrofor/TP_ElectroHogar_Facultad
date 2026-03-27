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




public Usuario ValidarLogin(string usuario, string contraseña)
{
    var usuarios = ObtenerUsuariosMock();

    return usuarios.FirstOrDefault(u =>
        u.NombreUsuario == usuario &&
        u.Contraseña == contraseña);
}