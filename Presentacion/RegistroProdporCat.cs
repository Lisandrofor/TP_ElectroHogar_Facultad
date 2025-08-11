using Modelo;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Presentacion
{
    public partial class RegistroProdporCat : Form
    {
        
        public RegistroProdporCat()
        {
            InitializeComponent();
            MostrarCategorias();
            

        }

        


        GestordeProductos gestorCategoria = new GestordeProductos();
        private void btnRegistrar_Click(object sender, EventArgs e)
        {


           









           




            try
            {
                // Cargar productos según la categoría seleccionada al cargar el formulario
                if (comboBox1.SelectedItem != null)
                {
                    CargarProductos();
                }

                // Asignar evento al cambio de selección del ComboBox
                comboBox1.SelectedIndexChanged += (s, ev) => CargarProductos();



            }
            catch (ArgumentNullException ex)
            {
               
            }























            BorrarCampos();
            MessageBox.Show($"Categoria Agregada Exitosamente");

        }

        


        public void MostrarCategorias()
        {
            List<Producto> lista = gestorCategoria.ObtenerCategorias();
            comboBox1.DataSource = lista;
            comboBox1.DisplayMember = "CategoriaDisplay";
        }

        private void BorrarCampos()
        {
           
           


        }
        public List<Producto> ListaProductosporCat()
        {
            var produ = (Producto)comboBox1.SelectedItem;
            if (produ == null) return new List<Producto>();

            return gestorCategoria.ObtenerProdporCategorias(produ.idCategoria);
        }



        private void CargarProductos()
        {

            List<Producto> productos = ListaProductosporCat();
            

            var bindingList = new BindingList<Producto>(productos);
            var source = new BindingSource(bindingList, null);
            dataGridView1.DataSource = source;
            
            

        }


    }
}







