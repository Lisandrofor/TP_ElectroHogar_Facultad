//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using Modelo;
//using Negocio;
////using AccesoaDatos;


//namespace Presentacion
//{
//    public partial class Login : Form
//    {
//        public Login()
//        {
//            InitializeComponent();
//        }

//        private void Login_Load(object sender, EventArgs e)
//        {

//        }

//        private void pictureBox1_Click(object sender, EventArgs e)
//        {

//        }

//        private void pictureBox2_Click(object sender, EventArgs e)
//        {

//        }

//        private void btnIngresar_Click(object sender, EventArgs e)
//        {
//            string idUsuario;
//            GestorDeUsuarios gestorusuarios = new GestorDeUsuarios();
            
//            string nombreUsuario = tbName.Text;
//            string contraseña = tbContraseña.Text;

//            Loginuser login = new Loginuser(nombreUsuario,contraseña);
//            login.NombreUsuario = nombreUsuario;
//            login.Contraseña = contraseña;

//            idUsuario = LoginMenu(gestorusuarios, nombreUsuario, contraseña);


            









//            this.Hide();
//            Form formulario = new MenuPrincipal();
//            formulario.Show();
//        }

//        private void button1_Click(object sender, EventArgs e)
//        {

//        }

//        private static string LoginMenu(GestorDeUsuarios gestorDeUsuarios, string nombreUsuario, string contraseña)
//        {

//            Loginuser loginuser = new Loginuser(nombreUsuario, contraseña);
//            loginuser.NombreUsuario = nombreUsuario;
//            loginuser.Contraseña = contraseña;

//            try
//            {
//                string idUsuario = gestorDeUsuarios.Login(login);
//                Console.WriteLine("Login exitoso. El idUusario es " + idUsuario);
//                gestorDeUsuarios.LimpiarListaDeControl(nombreUsuario);
//                return idUsuario;

//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("Error al hacer login.");
//                Console.WriteLine(ex.Message);

//                bool quedanIntentos = gestorDeUsuarios.ListaDeControl(nombreUsuario);

//                if (!quedanIntentos)
//                {
//                    Console.WriteLine("El usuario está bloqueado. Demasiados intentos fallidos.");
//                    return "error";
//                }
//            }

//            return "";


//        }


//    }
//}
