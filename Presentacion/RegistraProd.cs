using Modelo;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Presentacion
{
    public partial class RegistraProd : Form
    {
        
        public RegistraProd()
        {
            InitializeComponent();
            MostrarCategoriasProd();
            MostrarProveedrores();
            

        }
        
        GestordeProductos gestorCategoria = new GestordeProductos();
        GestordeProveedores gestorProve = new GestordeProveedores();
        Proveedor lista = new Proveedor();


        public void MostrarCategoriasProd()
        {


            
            List <Categorias> lista = gestorCategoria.ObtenerCategorias();

            lista.Insert(0, new Categorias(0, "Nueva categoría..."));
            comboBox1.DataSource = lista;
            comboBox1.DisplayMember = "Mostrar";

        }
        public void MostrarProveedrores()
        {
            List<Proveedor> listaProve = gestorProve.listarProveedores();
            comboBox2.DataSource = listaProve;
            comboBox2.DisplayMember = "nombre";
            comboBox2.ValueMember = "id";
        }

       

        GestordeProductos gestorProd = new GestordeProductos();


        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            float precio = float.Parse(textBox3.Text);
            int stock = int.Parse(textBox10.Text);
            string idproveedor = IdProveedor().ToString();
            int categoria = NumCategoria();

            Producto productoSeleccionado = (Producto)comboBox3.SelectedItem;
            string nombre = productoSeleccionado != null ? productoSeleccionado.nombre : "";

            try
            {
                gestorProd.AgregarProd(categoria, idproveedor, nombre, precio, stock);
                MessageBox.Show("Producto agregado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }




        }


        


        public Guid IdProveedor()
        {
            List<Proveedor> listaProve = gestorProve.listarProveedores();

            Proveedor proveedorSeleccionado = (Proveedor)comboBox2.SelectedItem;

            if (proveedorSeleccionado != null)
            {
                // Buscar el producto en la lista
                Proveedor proveedorEncontrado = listaProve.FirstOrDefault(p => p.id == proveedorSeleccionado.id);

                if (proveedorEncontrado.id != null)
                {
                    return proveedorEncontrado.id;
                }
                else
                {
                    MessageBox.Show("Proveedor no encontrado.");
                }


            }
            return Guid.Empty;


        }

        public int NumCategoria()
        {
            List<Categorias> lista = gestorCategoria.ObtenerCategorias();

            Categorias categoriaSeleccionada = (Categorias)comboBox1.SelectedItem;
            if (categoriaSeleccionada != null)
            {
                // Buscar la categoría en la lista
                Categorias categoriaEncontrada = lista.FirstOrDefault(c => c.IdCategoria == categoriaSeleccionada.IdCategoria);
                if (categoriaEncontrada != null)
                {
                    return categoriaEncontrada.IdCategoria;
                }
                else
                {
                    MessageBox.Show("Categoría no encontrada.");
                }

            }
            return categoriaSeleccionada.IdCategoria = 0;
        }


        public List<Producto> DevuelveListaProductos(int categoria)
        {
            // Traigo las categorías y los productos
            List<Categorias> lista = gestorCategoria.ObtenerCategorias();
            List<Producto> listaProd = gestorProd.listarProductos();

            // Obtengo la categoría seleccionada en el ComboBox
            //Categorias categoriaSeleccionada = (Categorias)comboBox1.SelectedItem;

            if (categoria != 0) // evito la opción "Nueva categoría..."
            {
                // Filtro los productos que coincidan con la categoría seleccionada
                List<Producto> productosFiltrados = listaProd
                    .Where(p => p.idCategoria == categoria)
                    .ToList();

                return productosFiltrados;
            }
            else
            {
                MessageBox.Show("Seleccione una categoría válida.");
                return new List<Producto>();
            }


        }

        

        public void MostrarProductos(int categoria)
        {
            List<Producto> listaProd = DevuelveListaProductos(categoria).ToList();
            comboBox3.DataSource = listaProd;
            comboBox3.DisplayMember = "nombre";

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Categorias categoriaSeleccionada = (Categorias)comboBox1.SelectedItem;

            if (categoriaSeleccionada != null && categoriaSeleccionada.IdCategoria != 0)
            {
                MostrarProductos(categoriaSeleccionada.IdCategoria);
            }
            else
            {
                comboBox3.DataSource = null;
            }

        }
    }


}











