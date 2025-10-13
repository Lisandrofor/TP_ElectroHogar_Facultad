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

namespace Presentacion
{
    public partial class LoginCambioPass : Form
    {
        Usuario usuario = new Usuario();
        public LoginCambioPass()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GestorDeUsuarios gestorUsuarios = new GestorDeUsuarios();
            string nombreUsuario = txtNombreUsuario.Text;
            string contraseña = txtPassword.Text;
            string contraseñaNueva = textBox2.Text;


            if (string.IsNullOrEmpty(nombreUsuario) || string.IsNullOrEmpty(contraseña) || string.IsNullOrEmpty(contraseñaNueva))
            {
                MessageBox.Show("Ingrese nombre de usuario, contraseña y Nueva Contraseña");
                return;
            }


            Loginuser loginnuevo = new Loginuser(nombreUsuario, contraseña);
            loginnuevo.NombreUsuario = nombreUsuario;
            loginnuevo.Contraseña = contraseña;
            loginnuevo.ContraseñaNueva = contraseñaNueva;


            gestorUsuarios.CambiarContraseña(nombreUsuario,contraseña,contraseñaNueva);
            string idUsuario = gestorUsuarios.Login(loginnuevo);



            if (!string.IsNullOrEmpty(idUsuario))
            {

                MessageBox.Show("¡Inicio de sesión exitoso!");
                Form Formulario = new MenuAdministrador(Usuario.EstadoUsuario.Activo,usuario.id,usuario.apellido);
                Formulario.Show();
                Hide();
            }
            else
            {

                MessageBox.Show("Error en el inicio de sesión. Verifique sus credenciales.");
            }
        }

        private void Ingresar_Load(object sender, EventArgs e)
            {

            }

            private void panel1_Paint(object sender, PaintEventArgs e)
            {

            }
        }
    }
