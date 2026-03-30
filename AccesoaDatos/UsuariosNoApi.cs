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



public void AgregarUsuarioMock(Usuario nuevoUsuario)
{
    string path = "Usuario.json";

    List<Usuario> usuarios = new List<Usuario>();

    // 1. Leer si existe
    if (File.Exists(path))
    {
        string jsonExistente = File.ReadAllText(path);
        usuarios = JsonSerializer.Deserialize<List<Usuario>>(jsonExistente)
                   ?? new List<Usuario>();
    }

    // 2. Agregar el nuevo
    usuarios.Add(nuevoUsuario);

    // 3. Guardar todo
    var json = JsonSerializer.Serialize(usuarios, new JsonSerializerOptions
    {
        WriteIndented = true
    });

    File.WriteAllText(path, json);
}

public void BorrarUsuario(Guid idUsuario)
{
    string path = "Usuarios.json";

    // 1. Leer archivo
    string json = File.ReadAllText(path);
    List<Usuario> lista = JsonConvert.DeserializeObject<List<Usuario>>(json);

    // 2. Buscar usuario
    Usuario usuarioAEliminar = lista.Find(u => u.Id == idUsuario);

    if (usuarioAEliminar != null)
    {
        // 3. Eliminar
        lista.Remove(usuarioAEliminar);

        // 4. Guardar nuevamente
        string nuevoJson = JsonConvert.SerializeObject(lista, Formatting.Indented);
        File.WriteAllText(path, nuevoJson);
    }
}
