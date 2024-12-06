using Modelo;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Presentacion
{
    public partial class RegistroClientes : Form
    {



        public RegistroClientes()
        {
            InitializeComponent();
            cargarUsuarios();


        }

       









        public void btnRegistrarUsuario_Click(object sender, EventArgs e)

        {
            GestordeClientes gestorCliente1 = new GestordeClientes();


            string nombre = tbNombre.Text;
            string apellido = tbApellido.Text;
            int dni = int.Parse(tbDNI.Text);
            string direccion = tbDireccion.Text;
            string email = tbEmail.Text;
            string telefono = tbTelefono.Text;
            DateTime fechaNacimiento = DateTime.Parse(TbFechaNac.Text);
            string host = "grupo x";





            gestorCliente1.ValidarNombre(nombre);
            gestorCliente1.ValidarApellido(apellido);
            



            try
            {
                // Llamada al método AgregarUsuario con los parámetros adecuados
                gestorCliente1.AgregarClientes(nombre,apellido, dni, direccion,telefono,email,
                             fechaNacimiento, host);

                // Si llegamos aquí, la operación fue exitosa
                Console.WriteLine("Usuario agregado correctamente.");
            }
            catch (ArgumentNullException ex)
            {
                // Captura la excepción si alguno de los argumentos es null
                Console.WriteLine("Error: Uno de los argumentos es nulo.");
                Console.WriteLine(ex.Message);
            }





















            BorrarCampos();
            MessageBox.Show($"Usuario Agregado Exitosamente");










        }


        private void BorrarCampos()
        {
            tbNombre.Clear();
            tbApellido.Clear();
            tbDNI.Clear();
            tbDireccion.Clear();
            tbTelefono.Clear();
            TbFechaNac.Clear();


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Usuario UsuarioSeleccionado = (Usuario)dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].DataBoundItem;

            Guid id = UsuarioSeleccionado.id;
            tbNombre.Text = UsuarioSeleccionado.nombre;
            tbApellido.Text = UsuarioSeleccionado.apellido;
            tbDNI.Text = UsuarioSeleccionado.dni.ToString();
           

            cargarUsuarios();

            //tbDireccion.Text = UsuarioSeleccionado.direccion;
            //tbTelefono.Text = UsuarioSeleccionado.telefono;

            //    txtApellido.Text = UsuarioSeleccionado.Apellido;
            //    txtDni.Text = UsuarioSeleccionado.Dni.ToString();
            //    txtDireccion.Text = UsuarioSeleccionado.Direccion;
            //    txtTelefono.Text = UsuarioSeleccionado.Telefono;
            //    txtMail.Text = UsuarioSeleccionado.Email;
            //    dtpFechaNacimiento.Value = UsuarioSeleccionado.FechaNacimiento;

        }

        private void cargarUsuarios()
        {
            GestorDeUsuarios gestorUsuarios = new GestorDeUsuarios();
            List<Usuario> Usuarios = gestorUsuarios.listarUsuarios();


            var bindingList = new BindingList<Usuario>(Usuarios);
            var source = new BindingSource(bindingList, null);
            dataGridView1.DataSource = source;

        }

       
    }
}
