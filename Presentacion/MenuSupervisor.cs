using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Presentacion
{
    public partial class MenuSupervisor : Form
    {

        LoginNuevo Cambiar = new LoginNuevo();
        public MenuSupervisor(Usuario.EstadoUsuario estado)
        {
            InitializeComponent();
            MenuSupervisor_Load(estado);
        }

       




        private void MenuSupervisor_Load(Usuario.EstadoUsuario estado)
        {
            string mensaje = Cambiar.CambiarEstado(estado);
            label1.Text = "SUPERVISOR - " + mensaje;
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

        private void BtnCerrar_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
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

       

        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AltaProducto(object sender, EventArgs e)
        {

        }

        private void PanelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
