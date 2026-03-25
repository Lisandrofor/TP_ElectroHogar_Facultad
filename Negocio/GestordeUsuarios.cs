using AccesoaDatos;
using Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;




namespace Negocio
{
    public class GestorDeUsuarios
    {
        public void ValidarNombre(string nombre)
        {
            if (string.IsNullOrEmpty(nombre) || nombre.Length <= 2 || nombre.Any(char.IsDigit))
            {
                throw new ArgumentException("El nombre no puede estar vacío, debe tener por lo menos 2 caracteres y no puede contener números.");
            }
        }

        public void ValidarApellido(string apellido)
        {
            if (string.IsNullOrEmpty(apellido) || apellido.Length < 2 || apellido.Any(char.IsDigit))
            {
                throw new ArgumentException("El apellido no puede estar vacío, debe tener por lo menos 2 caracteres y no puede contener números.");
            }
        }

        public void ValidarUsername(string nombre, string apellido, string nombreUsuario)
        {
            if (nombreUsuario.Length < 8)
            {
                throw new ArgumentException("El nombre de usuario debe tener mínimo 8 caracteres.");
            }
            else if (nombreUsuario.Length > 15)
            {
                throw new ArgumentException("El nombre de usuario debe tener un máximo de 15 caracteres.");
            }
            else if (nombreUsuario.IndexOf(nombre, StringComparison.OrdinalIgnoreCase) >= 0 ||
                     nombreUsuario.IndexOf(apellido, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                throw new ArgumentException("El nombre de usuario no debe contener el nombre o el apellido.");
            }
        }



        Usuario Usuario = new Usuario();
        UsuarioDatos UsuarioService = new UsuarioDatos();
        
        readonly string idAdministrador ="70b37dc1-8fde-4840-be47-9ababd0ee7e5";
        



        public void AgregarUsuario(string nombre,int dni,string direccion,string telefono,string apellido,
                        string email,DateTime fechaNacimiento,string nombreUsuario,string contraseña,int host)
        {
            //string idUsuario = Guid.NewGuid().ToString();

            AltaUsuario altaUsuario = new AltaUsuario(idAdministrador,host,nombre,apellido,dni,direccion,telefono,email,fechaNacimiento,nombreUsuario,contraseña);

            try
            {
                UsuarioService.AgregarUsuario(altaUsuario);


                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error general: " + ex.Message);
            }

        }

        public void CambiarContraseña(string nombreUsuario, string contraseña, string contraseñaNueva)
        {
            Loginuser loginpass = new Loginuser(nombreUsuario, contraseña);
            loginpass.NombreUsuario = nombreUsuario;
            loginpass.Contraseña = contraseña;
            loginpass.ContraseñaNueva = contraseñaNueva;
            loginpass.FechaAlta = DateTime.Now;

            UsuarioService.CambiarContraseña(nombreUsuario, contraseña, contraseñaNueva);



        }












        public String Login(Loginuser login)
        {
            String idUsuario = UsuarioService.Login(login);
            
            return idUsuario;

           
        }

        
        


        public event Action<Usuario.EstadoUsuario> CambiarEstadoactual;



           
       
            

        




        public void ModificarUsuario(Guid idUsuario, string direccion, string telefono, string email)
        {
            UsuarioService.ModificarUsuario(idUsuario, direccion, telefono, email);

        }

        public List<Usuario> listarUsuarios()
        {
            return UsuarioService.getUsuarios();
        }

        public void BorrarUsuario(Guid idUsuario)
        {
            UsuarioService.BorrarUsuario(idUsuario);
        }

        public void GuardarContraseñas(Usuario loginUsuario)
        {
            List<Usuario> listaContraseñas = new List<Usuario>();

            string rutaArchivo = "C:\\Users\\vlisa\\source\\repos\\TP_ElectroHogar_Facultad\\AccesoaDatos\\Contraseñas.json";
            if (File.Exists(rutaArchivo))
            {
                string jsonArchivo = File.ReadAllText(rutaArchivo);

                if (string.IsNullOrWhiteSpace(jsonArchivo))
                {
                    listaContraseñas = new List<Usuario>();
                }
                else
                {
                    listaContraseñas = JsonConvert.DeserializeObject<List<Usuario>>(jsonArchivo);
                }
            }
            else
            {
                listaContraseñas = new List<Usuario>();
            }

            // 🔹 agregar la nueva venta
            listaContraseñas.Add(loginUsuario);

            // 🔹 convertir a json
            string nuevoJson = JsonConvert.SerializeObject(listaContraseñas, Formatting.Indented);

            // 🔹 guardar archivo
            File.WriteAllText(rutaArchivo, nuevoJson);





        






    }


        public List<Usuario> ObtenerContraseñas(Usuario LoginUsuario)
        {
            string rutaArchivo = "C:\\Users\\vlisa\\source\\repos\\TP_ElectroHogar_Facultad\\AccesoaDatos\\Contraseñas.json";
            try
            {
                string jsonLeer = File.ReadAllText(rutaArchivo);
                List<Usuario> listaContraseñas = JsonConvert.DeserializeObject<List<Usuario>>(jsonLeer);

                if (listaContraseñas == null)
                {
                    listaContraseñas = new List<Usuario>(); // Retorna una lista vacía si el archivo estaba vacío o no se pudo deserializar
                }

                return listaContraseñas;
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error al deserializar el archivo JSON: {ex.Message}");
                return new List<Usuario>(); // Retorna una lista vacía en caso de error
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error al leer el archivo: {ex.Message}");
                return new List<Usuario>(); // Retorna una lista vacía en caso de error
            }
        }






    }
}
