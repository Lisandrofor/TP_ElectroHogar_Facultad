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
using Presentacion;
using Negocio;
using Modelo;


namespace Presentacion
{
    public partial class MenuPrincipal : Form
    {

       
        public MenuPrincipal()
        {
            InitializeComponent();
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

        

        private void LoginClick_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new LoginNuevo());
           
        }

        public void btnRegistrese_Click(object sender, EventArgs e)
        {

           

            Registrese formRegistrese = new Registrese();
            formRegistrese.UsarHost(3);
            AbrirFormEnPanel(formRegistrese);


           


            
        }



        private void MenuAdministrador_Load(Object sender, EventArgs e)
        {

        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lparam);



        

        private void BtnMInimizar_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnRestaurar_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            BtnRestaurar.Visible = false;
            BtnMaximizar.Visible = true;

        }

        private void BtnMaximizar_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            BtnMaximizar.Visible = false;
            BtnRestaurar.Visible = true;

        }

        private void BtnCerrar_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void barraTitulo_MouseDown_1(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

       
    }
}
