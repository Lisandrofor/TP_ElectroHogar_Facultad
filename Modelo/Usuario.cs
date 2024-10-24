using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;



namespace Modelo
{
    public class Usuario
    {
        Guid _id;
        string _nombre;
        string _apellido;
        int _dni;
        string _direccion;
        string _telefono;
        string _email;
        string _Categoria;
        DateTime _fechaNacimiento;
        DateTime _fechaAlta;
        DateTime? _fechaBaja;
        string _nombreUsuario;
        int _host;
        string _contraseña;


        public Usuario()
        {
        }

        

        public Usuario(Guid id,string nombre, string apellido, int dni, string nombreUsuario,int host)
        {
            _id = id;
            _nombre = nombre;
            _apellido = apellido;
            _dni = dni;
            _nombreUsuario = nombreUsuario;
            _host = host;
        }

        public Guid id { get => _id; set => _id = value; }
        
        public string nombre { get => _nombre; set => _nombre = value; }
        public string apellido { get => _apellido; set => _apellido = value; }
        public int dni { get => _dni; set => _dni = value; }
        public string direccion { get => _direccion; set => _direccion = value; }
        public string telefono { get => _telefono; set => _telefono = value; }
        public string email { get => _email; set => _email = value; }
        public string categoria { get => _Categoria; set => _Categoria = value; }
        public DateTime fechaNacimiento { get => _fechaNacimiento; set => _fechaNacimiento = value; }
        public DateTime fechaAlta { get => _fechaAlta; set => _fechaAlta = value; }
        public DateTime? fechaBaja { get => _fechaBaja; set => _fechaBaja = value; }

        public string nombreUsuario { get => _nombreUsuario; set => _nombreUsuario = value; }
        public int host { get => _host; set => _host = value; }


        public string contraseña { get => _contraseña; set => _contraseña = value; }


        public enum EstadoUsuario
        {
            Activo,
            Inactivo
        }

        public EstadoUsuario Estado { get; set; }





        public override String ToString()
        {
            return this.apellido + ", " + this.nombre + " (" + this.dni + ")";
        }

    }



}

    //public class Lista
    //{


    //    public static  List<Usuario> listadeUsuarios = new List<Usuario>();

    //    public static void AgregarUsuario(Usuario nuevoUsuario)
    //    {
    //        listadeUsuarios.Add(nuevoUsuario);
    //        //CargarUsuarios(listadeUsuarios);



    //    }


        //private static void CargarUsuarios(List<RegistroUsuario> listadeUsuarios)
        //{

        //    string docPath =




        //    using (StreamWriter registro = new StreamWriter(docPath, true))
        //    {
        //        foreach (RegistroUsuario registroUsuario in listadeUsuarios)
        //            registro.WriteLine(registroUsuario.Host + ";" + registroUsuario.IdUsuarioActual + ";" + registroUsuario.Nombre + ";" + registroUsuario.Apellido + ";" + registroUsuario.DNI + ";" + registroUsuario.Email + ";" + registroUsuario.Direccion + ";" + registroUsuario.Categoria + ";" + registroUsuario.NombreUsuario + ";" + registroUsuario.Contraseña);




        //    }



        //}







    















    
       

       



    

       



       


    












