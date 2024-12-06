using AccesoaDatos;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class GestordeClientes
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

        



        Usuario Usuario = new Usuario();
        ClientesDatos ClientesDa = new ClientesDatos();

        readonly string idUsuario = "70b37dc1-8fde-4840-be47-9ababd0ee7e5";








        public void AgregarClientes(string nombre, string apellido,int dni, string direccion, string telefono, string email,DateTime fechaNacimiento,string host)
        {
            //string idUsuario = Guid.NewGuid().ToString();

            

            AltaCliente altaCli = new AltaCliente(idUsuario,nombre,apellido,dni,direccion,telefono, email,fechaNacimiento, host);

            try
            {
                ClientesDa.AgregarCliente(altaCli);



            }
            catch (Exception ex)
            {
                Console.WriteLine("Error general: " + ex.Message);
            }

        }





        public void ModificarCliente(Guid idUsuario, string direccion, string telefono, string email)
        {
            ClientesDa.ModificarCliente(idUsuario, direccion,telefono,email);

        }

        public List<Cliente> listarClientes()
        {
            return ClientesDa.getCliente();
        }

        public void BorrarCliente(Guid idUsuario)
        {
            ClientesDa.BorrarCliente(idUsuario);
        }



    }
}
