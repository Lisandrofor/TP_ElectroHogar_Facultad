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


        private void RegistroProdporCat_Load(object sender, EventArgs e)
        {
            // Cargar los productos al inicio si hay una categoría seleccionada al inicio
            CargarProductos();
        }

        GestordeProductos gestorCategoria = new GestordeProductos();
        private void btnRegistrar_Click(object sender, EventArgs e)
        {




           
            






            //gestorCliente1.ValidarNombre(nombre);
            //gestorCliente1.ValidarApellido(apellido);




            try
            {
               


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
            comboBox1.DisplayMember = "idCategoria"+ "nomCategoria";
        }

        private void BorrarCampos()
        {
           
           


        }
        public List<Producto> ListaProductosporCat(Producto producto)
        {
            List<Producto> prod = gestorCategoria.ObtenerProdporCategorias(producto.idCategoria);
            Producto produ = (Producto)comboBox1.SelectedItem;
            if (produ != null)
            {
                var productosfiltrados=prod.Where(p=>p.idCategoria==produ.idCategoria).ToList();
                return productosfiltrados;

            }
            return prod;
        }


        private void CargarProductos(Producto producto)
        {

            List<Producto> productos = ListaProductosporCat(producto);
            

            var bindingList = new BindingList<Producto>(productos);
            var source = new BindingSource(bindingList, null);
            dataGridView1.DataSource = source;
            
            

        }


    }
}







