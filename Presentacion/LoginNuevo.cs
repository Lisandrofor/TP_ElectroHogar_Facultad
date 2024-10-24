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
using Modelo;

namespace Presentacion
{
    
    public partial class LoginNuevo : Form
    {
        
        MenuPrincipal menu = new MenuPrincipal();
       
        public LoginNuevo()
        {
            InitializeComponent();
            menu.Close();
            
        }

        
       


        private void button1_Click(object sender, EventArgs e)
        {


            GestorDeUsuarios gestorUsuarios = new GestorDeUsuarios();
            string nombreUsuario = txtNombreUsuario.Text;
            string contraseña = txtPassword.Text;
            


            if (string.IsNullOrEmpty(nombreUsuario) || string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("Ingrese nombre de usuario y contraseña.");
                return;
            }


            Loginuser login = new Loginuser(nombreUsuario, contraseña);
            LoginNuevo login1 = new LoginNuevo();
            string idUsuario = gestorUsuarios.Login(login);
            

           
            bool ingresos= login.IngresosUsuario(idUsuario,nombreUsuario,contraseña);
            MenuAdministrador adm = new MenuAdministrador(Usuario.EstadoUsuario.Inactivo);


            if (contraseña != "Temp1234")
            {

                if (!string.IsNullOrEmpty(idUsuario))
                {

                    MessageBox.Show("¡Inicio de sesión exitoso!");
                    Form Formulario = new MenuAdministrador(Usuario.EstadoUsuario.Activo);
                    Formulario.Show();
                    Hide();
                }
                else
                {

                    MessageBox.Show("Error en el inicio de sesión. Verifique sus credenciales.");
                }

            }
            else if (contraseña == "Temp1234")

            {   if (ingresos== true)
                {   
                    
                    LoginCambioPass cambioPass = new LoginCambioPass();

                    if (cambioPass.ShowDialog() == DialogResult.OK) // Si el cambio de contraseña se realiza correctamente
                    {
                        string contraseñaNueva = login.ContraseñaNueva;// Suponiendo que tienes esta propiedad en LoginCambioPass
                        gestorUsuarios.CambiarContraseña(nombreUsuario, contraseña, contraseñaNueva);


                        LoginCambioPass cambiopass = new LoginCambioPass();
                        login1.Close();
                        cambiopass.ShowDialog();
                        gestorUsuarios.CambiarContraseña(login.NombreUsuario, login.Contraseña, login.ContraseñaNueva);
                        Hide();
                    }


                    

                }else if (ingresos==false)
                {
                    

                    MessageBox.Show("¡Inicio de sesión exitoso!");

                    Form Formulario = new MenuAdministrador(Usuario.EstadoUsuario.Inactivo);
                    Formulario.Show();
                    
                    adm.CambiarEstado(Usuario.EstadoUsuario.Inactivo);
                    





                    Hide();

                }

            }





































        }




        private void Ingresar_Load(object sender, EventArgs e)
        {

        }




    }
}