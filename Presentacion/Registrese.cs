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
    public partial class Registrese : Form
    {

       

        public Registrese()
        {
            InitializeComponent();
            cargarUsuarios();
            
            
        }

        //public Usuario usuario { get; set; }

        Usuario usuario = new Usuario(); 
       
        public int UsarHost(int host)
        {
           

            usuario.host = host; ;
            
            return usuario.host ;
        }




        
       



        public void btnRegistrarUsuario_Click(object sender, EventArgs e)

        {
            GestorDeUsuarios gestorUsuario1 = new GestorDeUsuarios();

            
            string nombre = tbNombre.Text;
            string apellido = tbApellido.Text;
            int dni = int.Parse(tbDNI.Text);
            string direccion = tbDireccion.Text;
            string email = tbEmail.Text;
            string telefono = tbTelefono.Text;
            string nombreUsuario = tbUsuario.Text;
            string contraseña = tbContraseña.Text;
            DateTime fechaNacimiento = DateTime.Parse(TbFechaNac.Text);
            int host = UsarHost(usuario.host);

           



            gestorUsuario1.ValidarNombre(nombre);
            gestorUsuario1.ValidarApellido(apellido);
            gestorUsuario1.ValidarUsername(nombre, apellido, nombreUsuario);


            if (((host == 2) || (host == 1)))
                {
                if ((contraseña == "Temp1234"))
                { 


                try
                {
                    // Llamada al método AgregarUsuario con los parámetros adecuados
                    gestorUsuario1.AgregarUsuario(nombre, dni, direccion, telefono, apellido, email,
                                 fechaNacimiento, nombreUsuario, contraseña, host);

                    // Si llegamos aquí, la operación fue exitosa
                    Console.WriteLine("Usuario agregado correctamente.");
                }
                catch (ArgumentNullException ex)
                {
                    // Captura la excepción si alguno de los argumentos es null
                    Console.WriteLine("Error: Uno de los argumentos es nulo.");
                    Console.WriteLine(ex.Message);
                }




                }
                else
                {

                MessageBox.Show("Por favor Ingrese contraseña temporal:Temp1234");
                }
                if (host == 3)
                {
                    try
                    {
                        // Llamada al método AgregarUsuario con los parámetros adecuados
                        gestorUsuario1.AgregarUsuario(nombre, dni, direccion, telefono, apellido, email,
                                     fechaNacimiento, nombreUsuario, contraseña, host);

                        // Si llegamos aquí, la operación fue exitosa
                        Console.WriteLine("Usuario agregado correctamente.");
                    }
                    catch (ArgumentNullException ex)
                    {
                        // Captura la excepción si alguno de los argumentos es null
                        Console.WriteLine("Error: Uno de los argumentos es nulo.");
                        Console.WriteLine(ex.Message);
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        // Captura la excepción si alguno de los argumentos está fuera de rango
                        Console.WriteLine("Error: Uno de los argumentos está fuera de rango.");
                        Console.WriteLine(ex.Message);
                    }
                    catch (Exception ex)
                    {
                        // Captura cualquier otra excepción que pueda ocurrir
                        Console.WriteLine("Error al agregar usuario: " + ex.Message);
                    }

                }
















                BorrarCampos();
                MessageBox.Show($"Usuario Agregado Exitosamente");




            }
            else
            {




            }
            

        }

       




        


        private void BorrarCampos()
        {
            tbNombre.Clear();
            tbApellido.Clear();
            tbDNI.Clear();
            tbDireccion.Clear();
            tbTelefono.Clear();
            tbUsuario.Clear();
            tbContraseña.Clear();
            TbFechaNac.Clear();


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Usuario UsuarioSeleccionado = (Usuario)dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].DataBoundItem;

            Guid id = UsuarioSeleccionado.id;
            tbNombre.Text = UsuarioSeleccionado.nombre;
            tbApellido.Text = UsuarioSeleccionado.apellido;
            tbDNI.Text = UsuarioSeleccionado.dni.ToString();
            tbUsuario.Text = UsuarioSeleccionado.nombreUsuario;

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
