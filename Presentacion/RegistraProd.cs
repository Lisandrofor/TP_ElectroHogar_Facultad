using Modelo;
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
            MostrarCategorias();
        }

        GestordeProductos gestorCategoria = new GestordeProductos();
        GestordeProveedores gestorProve = new GestordeProveedores();
        Proveedor lista = new Proveedor();

        
        public void MostrarCategoriasProd()
        {
            List<Producto> lista = gestorCategoria.ObtenerCategorias();
            comboBox1.DataSource = lista;
            comboBox1.DisplayMember = "nomCategoria" + "idCategoria";

        }
        public void MostrarCategorias()
        {
            List<Proveedor> listaProve = gestorProve.listarProveedores();
            comboBox2.DataSource = listaProve;
            comboBox2.DisplayMember = "nombre";
            comboBox2.ValueMember = "id";




        }

        GestordeProductos gestorProd = new GestordeProductos();


        private void btnRegistrar_Click(object sender, EventArgs e)
        {



            string nombre = textBox2.Text;
            float precio = float.Parse(textBox3.Text);
            int stock = int.Parse(textBox10.Text);
            string idproveedor = IdProveedor().ToString();
            int categoria = NumCategoria();




            try
            {
                // Llamada al método AgregarUsuario con los parámetros adecuados
                gestorProd.AgregarProd(categoria,idproveedor,nombre,precio,stock);
                // Si llegamos aquí, la operación fue exitosa
                Console.WriteLine("Usuario agregado correctamente.");
            }
            catch (ArgumentNullException ex)
            {
                // Captura la excepción si alguno de los argumentos es null
                Console.WriteLine("Error: Uno de los argumentos es nulo.");
                Console.WriteLine(ex.Message);
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
            List<Producto> lista = gestorCategoria.ObtenerCategorias();
            Producto productoSeleccionado = (Producto)comboBox1.SelectedItem;

            if (productoSeleccionado!=null)
            {
                Producto productoEncontrado= lista.FirstOrDefault(prod=>prod.idCategoria==productoSeleccionado.idCategoria);

                    if (productoEncontrado!=null)
                    {
                    return productoEncontrado.idCategoria;
                    }
                    else
                    {

                    }
            }

            return productoSeleccionado.idCategoria = 0;
            



        }


    }


}








    


                

            
