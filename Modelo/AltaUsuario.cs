using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    //WS se usa para deserializar
    //tiene todos los atributos de la response body del GET 

    public class AltaUsuario
    {
        string _id;
        string _idUsuario;
        int _host;
        string _nombre;
        string _apellido;
        int _dni;
        string _direccion;
        string _telefono;
        string _email;
        DateTime _fechaNacimiento;
        string _nombreUsuario;
        string _contraseña;

        public AltaUsuario(string idUsuario,int host,string nombre, string apellido, int dni, string direccion, string telefono, string email, DateTime fechaNacimiento,string nombreUsuario, string contraseña)
        {
            _idUsuario = idUsuario;
            _host = host;
            _nombre = nombre; 
            _apellido = apellido;
            _dni = dni;
            _direccion = direccion;
            _telefono = telefono;
            _email = email;
            _fechaNacimiento = fechaNacimiento;
            _nombreUsuario = nombreUsuario;
            _contraseña = contraseña;
            
        }

        public string id { get => _id; set => _id = value; }
        public string idUsuario { get => _idUsuario; set => _idUsuario = value; }
        public int host { get => _host; set => _host = value; }
        public string nombre { get => _nombre; set => _nombre = value; }
        public string apellido { get => _apellido; set => _apellido = value; }
        public int dni { get => _dni; set => _dni = value; }
        public string direccion { get => _direccion; set => _direccion = value; }
        public string telefono { get => _telefono; set => _telefono = value; }
        public string email { get => _email; set => _email = value; }
        public DateTime fechaNacimiento { get => _fechaNacimiento; set => _fechaNacimiento = value; }
        public string nombreUsuario { get => _nombreUsuario; set => _nombreUsuario = value; }
        public string contraseña { get => _contraseña; set => _contraseña = value; }
    }

}