using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using Negocio;
using Modelo;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Presentacion
{
    public partial class MenuAdministrador : Form
    {

        Usuario Usuario = new Usuario();
        GestorDeUsuarios GestorDeUsuarios = new GestorDeUsuarios();


       

        public MenuAdministrador(Usuario.EstadoUsuario estadoUsuario)
        {
            
            
            InitializeComponent();
            disenosubmenu();
            
            
            CambiarEstado(estadoUsuario);


        }

        public void CambiarEstado(Usuario.EstadoUsuario estadoUsuario)
        {

            if (estadoUsuario == Usuario.EstadoUsuario.Inactivo)
            {
                label1.Text = "ADMINISTRADOR - Inactivo";


            }
            else
            {
                label1.Text = "ADMINISTRADOR - Activo";

            }



        }






        public void AbrirFormEnPanel(object formhija)
        {
            if (this.PanelContenedor.Controls.Count > 0)
                this.PanelContenedor.Controls.RemoveAt(0);
            Form fh = formhija as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.PanelContenedor.Controls.Add(fh);
            this.PanelContenedor.Tag = fh;
            fh.Show();

        }




        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            BtnMaximizar.Visible = false;
            BtnRestaurar.Visible = true;
        }

        private void BtnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            BtnRestaurar.Visible = false;
            BtnMaximizar.Visible = true;

        }

        private void BtnMInimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void MenuAdministrador_Load(Object sender, EventArgs e )
        {

        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lparam);

        

        private void barraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void AltaSupervisor_Click(object sender, EventArgs e)
        {
            
           
            //AbrirFormEnPanel(new Registrese());
            //ocultarsubmenu();

            Usuario usuario = new Usuario { host = 2 }; // Establece el valor de host
            Registrese formRegistrese = new Registrese();
            formRegistrese.Usuario = usuario; // Asigna la instancia de Usuario
            AbrirFormEnPanel(formRegistrese);
            ocultarsubmenu();


        }

        private void disenosubmenu()
        {
            panelSupervisor.Visible = false;
            panelVendedor.Visible = false;
            PanelProveedor.Visible = false;
            panelProducto.Visible = false;
        }

        private void ocultarsubmenu()
        { if (panelSupervisor.Visible==true)
            {
                panelSupervisor.Visible = false;
            }
            if (panelVendedor.Visible == true)
            {
                panelVendedor.Visible = false;
            }
            if (PanelProveedor.Visible== true)
            {
                PanelProveedor.Visible = false;
            }
            if (panelProducto.Visible== true)
            {
                panelProducto.Visible = false;
            }    
        }

        private void showSubMenu (Panel Submenu)
        {
            if (Submenu.Visible == false)
            {
                ocultarsubmenu();
                Submenu.Visible = true;
            }
            else
            {
                Submenu.Visible = false;
            }
            
        }

        private void Supervisor_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSupervisor);
        }

        private void Vendedor_Click(object sender, EventArgs e)
        {
            showSubMenu(panelVendedor);
        }

        private void PROVEEDOR_Click(object sender, EventArgs e)
        {
            showSubMenu(PanelProveedor);
        }

        private void Producto_Click(object sender, EventArgs e)
        {
            showSubMenu(panelProducto);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ocultarsubmenu();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ocultarsubmenu();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ocultarsubmenu();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ocultarsubmenu();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ocultarsubmenu();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }


        //private void MiFormulario_Load(object sender, EventArgs e)
        //{
        //    Asignar el valor del enum a la barra de título
        //    this.Text = MiEnum.Opcion1.ToString(); // Cambia Opcion1 por el valor que necesites
        //}
    }
}
