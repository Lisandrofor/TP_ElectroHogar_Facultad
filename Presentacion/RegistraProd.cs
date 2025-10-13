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
        private Guid idUsuario;

        public RegistraProd(Guid id)
        {
            idUsuario = id;
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
            // --- Validaciones básicas ---
            if (string.IsNullOrWhiteSpace(comboBox3.Text))
            {
                MessageBox.Show("Debe ingresar o seleccionar un nombre de producto.");
                return;
            }

            if (!float.TryParse(textBox3.Text, out float precio))
            {
                MessageBox.Show("Precio inválido.");
                return;
            }

            if (!int.TryParse(textBox10.Text, out int stock))
            {
                MessageBox.Show("Stock inválido.");
                return;
            }

            string idproveedor = IdProveedor().ToString();
            int categoria = NumCategoria();
            string nombre = comboBox3.Text.Trim();

            try
            {
                Producto productoSeleccionado = comboBox3.SelectedItem as Producto;

                // Si el usuario seleccionó un producto existente
                if (productoSeleccionado != null && !string.IsNullOrEmpty(productoSeleccionado.nombre))
                {
                    stock= stock + productoSeleccionado.stock;
                    // Actualiza stock/precio o lo que necesites
                    gestorProd.AgregarProd(categoria, idproveedor, productoSeleccionado.nombre, precio, stock);
                    gestorProd.ModificarProducto(productoSeleccionado.id,idUsuario, precio, stock);
                    MessageBox.Show("Producto existente actualizado correctamente.");
                }
                else
                {
                    // --- Usuario escribió un nombre nuevo ---
                    // 🔹 Guardar el nuevo producto directamente en la base
                    gestorProd.AgregarProd(categoria, idproveedor, nombre, precio, stock);

                    // 🔹 Crear el objeto nuevo (solo para mostrarlo en la lista visualmente)
                    Producto nuevoProducto = new Producto
                    {
                        nombre = nombre,
                        precio = precio,
                        stock = stock
                        // Si AgregarProd devuelve el ID, podrías asignarlo aquí
                    };

                    // 🔹 Agregarlo al ComboBox
                    listaProdBinding.Add(nuevoProducto);
                    comboBox3.SelectedItem = nuevoProducto;


                    MessageBox.Show("Producto nuevo agregado correctamente a la base de datos.");
                }
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

                if (proveedorEncontrado!= null)
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

        private BindingList<Producto> listaProdBinding;

        public void MostrarProductos(int categoria)
        {

            var listaProd = DevuelveListaProductos(categoria).ToList();

            listaProd.Insert(0, new Producto { nombre = "" });
            listaProdBinding = new BindingList<Producto>(listaProd);
            comboBox3.DataSource = null;
            // Configura el ComboBox con enlace de datos
            comboBox3.DataSource = listaProdBinding;
            comboBox3.DisplayMember = "nombre";
            comboBox3.ValueMember = "id";  // ← tu propiedad Guid

            dataGridView1.DataSource = null;              // Limpio el origen anterior
            dataGridView1.AutoGenerateColumns = true;     // Genera las columnas automáticamente
            dataGridView1.DataSource = listaProdBinding;


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











