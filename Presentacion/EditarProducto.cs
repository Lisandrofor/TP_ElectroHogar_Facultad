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

namespace Presentacion
{
    public partial class EditarProducto : Form
    {
        GestordeProductos GestorProd = new GestordeProductos();
        private string iduser;

        public EditarProducto(Usuario usuario)
        {
            InitializeComponent();
            MostrarProductos();
            MostrarProductosEliminados();
            CargarProductosEnGrilla();

            iduser =usuario.id.ToString();
            
            
        }
        private void MostrarProductos()
        {
            // Lógica para mostrar productos en el formulario
            List<Producto> listaProd = GestorProd.listarProductos();
            comboBox1.DataSource = listaProd;
            comboBox1.DisplayMember = "nombre";
            comboBox1.ValueMember = "id";
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Producto productoSeleccionado = comboBox1.SelectedItem as Producto;

            // Si el usuario seleccionó un producto existente
            if (productoSeleccionado != null && !string.IsNullOrEmpty(productoSeleccionado.nombre))
                
                    {
               
                GestorProd.BorrarProductos(productoSeleccionado,iduser);
                GestorProd.GuardarProductosEliminados(productoSeleccionado,iduser);
                MessageBox.Show("Producto Eliminado exitosamente.");
            }
            else
            {
                MessageBox.Show("Debe seleccionar un producto existente para editar.");
            }










        }
        private void MostrarProductosEliminados()
        {

            // Lógica para mostrar productos en el formulario
            List<Producto> listaProdElim = GestorProd.ObtenerProductosEliminados();
            comboBox2.DataSource = listaProdElim;
            comboBox2.DisplayMember = "nombre";
            comboBox2.ValueMember = "id";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Producto productoSeleccionado = comboBox2.SelectedItem as Producto;

            GestorProd.ReactivarProducto(productoSeleccionado.id,iduser);
        }

        private void dgvProductos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Producto prod = (Producto)dgvProductos.Rows[e.RowIndex].DataBoundItem;

            // Ejemplo: si cambió precio, validamos
            if (dgvProductos.Columns[e.ColumnIndex].Name == "Precio")
            {
                if (prod.precio < 0)
                {
                    MessageBox.Show("El precio no puede ser negativo");
                    prod.precio = 0;
                    dgvProductos.Refresh();
                }
            }
        }







        BindingList<Producto> listaBinding;

        private void CargarProductosEnGrilla()
        {
            // Traés la lista desde la API
            List<Producto> listaProductos = GestorProd.listarProductos();

            // Se envuelve en BindingList para permitir edición
            listaBinding = new BindingList<Producto>(listaProductos);

            dgvProductos.AutoGenerateColumns = true;
            dgvProductos.DataSource = listaBinding;
        }




        private void button3_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow != null)
            {
                DataGridViewRow row = dgvProductos.CurrentRow;

                Producto prod = new Producto();
                prod.nombre = row.Cells["Nombre"].Value.ToString();
                prod.precio = Convert.ToDouble(row.Cells["Precio"].Value);
                prod.stock = Convert.ToInt32(row.Cells["Stock"].Value);

                Guid idusuario = new Guid(iduser);

                GestorProd.ModificarProducto(prod.id, idusuario, prod.precio, prod.stock);

                // Aquí tenés el objeto modificado, lo podés guardar o actualizar tu lista
            }
        }
        List<Producto> productosSeleccionados = new List<Producto>();

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
                return;

            Producto productoSeleccionado = comboBox1.SelectedItem as Producto;

            if (productoSeleccionado == null)
                return;

            // Mostrar SOLO el producto seleccionado
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = new List<Producto> { productoSeleccionado };
        }



    }


        

       


    }

