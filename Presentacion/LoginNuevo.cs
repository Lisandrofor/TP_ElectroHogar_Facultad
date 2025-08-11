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
            


            bool ingresos = login.IngresosUsuario(idUsuario, nombreUsuario, contraseña);









            Usuario usuarioencontrado = ObtenerUsuarioPorId(idUsuario);



            //List<Usuario> listadoUsuarios = gestorUsuarios.listarUsuarios();

            //Usuario usuarioencontrado = listadoUsuarios.FirstOrDefault(user =>user.id.ToString()==idUsuario);

            if (usuarioencontrado != null)
            {
                if (contraseña != "Temp1234")
                {
                    if (!string.IsNullOrEmpty(idUsuario))
                    {
                        MessageBox.Show("¡Inicio de sesión exitoso!");
                        
                        
                        
                        Form formulario = IniciaForm(nombreUsuario, usuarioencontrado.host,Usuario.EstadoUsuario.Activo);

                        if (formulario != null)
                        {
                            formulario.Show();
                            login1.Close();
                            





                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("Error en el inicio de sesión. Verifique sus credenciales.");
                    }
                    
                }
                else if (contraseña == "Temp1234")
                {





                    if (ingresos == true)
                    {
                        LoginCambioPass cambioPass = new LoginCambioPass();

                        if (cambioPass.ShowDialog() == DialogResult.OK)
                        {
                            string contraseñaNueva = login.ContraseñaNueva;
                            gestorUsuarios.CambiarContraseña(nombreUsuario, contraseña, contraseñaNueva);

                            login1.Close();
                            cambioPass.ShowDialog();
                            gestorUsuarios.CambiarContraseña(login.NombreUsuario, login.Contraseña, login.ContraseñaNueva);
                            
                        }

                        Form formulario = IniciaForm(nombreUsuario, usuarioencontrado.host, Usuario.EstadoUsuario.Activo);

                        if (formulario != null)
                        {
                            formulario.Show();
                            
                        }
                        
                        
                        
                    }
                    else if (ingresos == false)
                    {
                        MessageBox.Show("¡Inicio de sesión exitoso!");

                        Form formulario = IniciaForm(nombreUsuario, usuarioencontrado.host,Usuario.EstadoUsuario.Inactivo);
                        

                        if (formulario != null)
                        {
                            formulario.Show();
                            
                            
                            
                        }

                        
                    }
                    
                }

                else
                {
                    MessageBox.Show("El usuario no fue encontrado. Verifique el ID.");
                }









               







            }

            
            
        }
       
        


        public Usuario ObtenerUsuarioPorId(string idBuscado)
        {
            GestorDeUsuarios gestorUsuarios = new GestorDeUsuarios();
            Usuario usuarioEncontrado = new Usuario();
            do
            {

                List<Usuario> listadoUsuarios = gestorUsuarios.listarUsuarios();
            } while (usuarioEncontrado.id.ToString()==idBuscado);

            if (usuarioEncontrado != null)
            {
                Console.WriteLine($"Usuario encontrado: {usuarioEncontrado.nombre}");
            }
            else
            {
                Console.WriteLine("Usuario no encontrado.");
            }

            return usuarioEncontrado;
        }


        






        public Form IniciaForm(string nombreUsuario, int host, Usuario.EstadoUsuario estado)
        {
            GestorDeUsuarios gestorUsuarios = new GestorDeUsuarios();
            List<Usuario> listadoUsuarios = gestorUsuarios.listarUsuarios();
           



            foreach (var usr in listadoUsuarios)
            {
               
                if (nombreUsuario == usr.nombreUsuario)
                {
                    Form formulario = null;

                    switch (usr.host)
                    {    
                        case 3:
                            formulario = new MenuAdministrador(estado);
                            break;
                        case 2:
                            formulario = new MenuSupervisor(estado);
                            break;
                        case 1:
                            formulario = new MenuVendedor(estado,usr.apellido,(usr.id).ToString());
                            break;
                        default:
                            // Manejo de caso si el host no es 1, 2 o 3
                            MessageBox.Show("Tipo de usuario no reconocido.");
                            // Salir si no se encuentra un caso válido
                            return null;

                    }

                    return formulario;
                    Hide();
                    break; // Salir del foreach si se encontró el usuario

                }

               

            }
            return null;
        }
        

        
        

        

        


       

        public string CambiarEstado(Usuario.EstadoUsuario estadoUsuario)
        {

            if (estadoUsuario == Usuario.EstadoUsuario.Inactivo)
            {
                return label1.Text = "Inactivo";


            }
            else
            {
                return label1.Text = "Activo";

            }



        }

 
       
        
        
    }
    
    
}



 







    