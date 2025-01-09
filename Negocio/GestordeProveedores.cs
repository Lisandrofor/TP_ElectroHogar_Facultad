using AccesoaDatos;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class GestordeProveedores
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
        ProveedoresDatos ProveedoresDa = new ProveedoresDatos();

        readonly string idUsuario = "70b37dc1-8fde-4840-be47-9ababd0ee7e5";








        public void AgregarProveedor(string nombre,string apellido, string cuit, string direccion, string telefono,string email,string categoria)
        {
            //string idUsuario = Guid.NewGuid().ToString();

            AltaProveedor altaProve = new AltaProveedor(idUsuario,nombre, apellido,email,cuit);

            try
            {
                ProveedoresDa.AgregarProveedor(altaProve);



            }
            catch (Exception ex)
            {
                Console.WriteLine("Error general: " + ex.Message);
            }

        }

        












       





        public event Action<Usuario.EstadoUsuario> CambiarEstadoactual;












        public void ModificarUsuario(Guid idProveedor,Guid idUsuario)
        {
            ProveedoresDa.ModificarProveedores(idProveedor,idUsuario);

        }

        public List<Proveedor> listarProveedores()
        {
            return ProveedoresDa.getProveedores();
        }

        public void BorrarProveedor(Guid idProveedor, Guid idUsuario)
        {
            ProveedoresDa.BorrarProveedor(idProveedor,idUsuario);
        }




    }
}
