using System;
using Modelo;
using Negocio;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Collections;

namespace Presentacion
{
    public partial class Venta : Form
    {
        public Venta()
        {
            InitializeComponent();
            MostrarProductos();
            
        }


        Cliente cliente=new Cliente();
        GestordeClientes clie = new GestordeClientes();
        GestordeProductos produ = new GestordeProductos();
        GestordeVentas venta=new GestordeVentas();



        public void MostrarProductos()
        {
            List<Producto> listaproductos = produ.listarProductos();
            comboBox1.DataSource = listaproductos;
            comboBox1.DisplayMember ="nombre";
        }

        private List<Producto> productos = new List<Producto>();

        private void btnRegistrar_Click(object sender, EventArgs e)
        {


            Producto productoSeleccionado = (Producto)comboBox1.SelectedItem;

            productos.Add(productoSeleccionado);

            var productosConNombre = productos.


            var bindingList = new BindingList<Producto>(productosConNombre);
            var source = new BindingSource(bindingList, null);
            dataGridView2.DataSource = source;







        }

       


        private void textBoxId_TextChanged(object sender, EventArgs e)
        {
            
            List<Cliente> listaCli = clie.listarClientes();

            if (int.TryParse(textBox1.Text, out int dni))
            {
                // Buscar la persona con el ID ingresado
                var cliente = listaCli.FirstOrDefault(c => c.dni == dni);

                if (cliente != null)
                {
                    // Si se encuentra la persona, mostrar el nombre y apellido
                    textBox2.Text = cliente.nombre+" " +cliente.apellido;
                }
                else
                {
                    MessageBox.Show("Registrese como Cliente Nuevo");
                }
            }
            else
            {
                // Si el texto no es un número válido, limpiar el resultado
                textBox2.Text = "No se encontró la persona con ese dni.";
            }
        }


        

       

    }
}
