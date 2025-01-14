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
using Modelo;

namespace Presentacion
{
    public partial class MenuVendedor : Form
    {
        LoginNuevo Cambiar = new LoginNuevo();

        public MenuVendedor(Usuario.EstadoUsuario estado)
        {
            InitializeComponent();
            MenuVendedor_Load(estado);
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





        private void MenuVendedor_Load(Usuario.EstadoUsuario estado)
        {
            string mensaje = Cambiar.CambiarEstado(estado);
            label1.Text = "VENDEDOR - " + mensaje;

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

        private void BtnRestaurar_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            BtnRestaurar.Visible = false;
            BtnMaximizar.Visible = true;

        }

        private void BtnMInimizar_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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

        private void button22_Click(object sender, EventArgs e)
        {
            RegistroClientes registroClientes = new RegistroClientes();

            AbrirFormEnPanel(registroClientes);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Venta registroventa = new Venta();
            AbrirFormEnPanel(registroventa);
        }
    }
}
