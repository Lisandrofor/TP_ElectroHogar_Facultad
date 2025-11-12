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
using static Modelo.Venta;

namespace Presentacion
{
    public partial class Ventas : Form
    {
        private string _idUsuario;
        private string _idCliente;
        private string _idProducto;
        private int _cantidad;


        public Ventas(string idUsuario)
        {
            InitializeComponent();
            MostrarProductos();

            _idUsuario = idUsuario;





        }


        Cliente cliente = new Cliente();
        GestordeClientes clie = new GestordeClientes();
        GestordeProductos produ = new GestordeProductos();
        GestordeVentas venta = new GestordeVentas();
        GestorDeUsuarios user = new GestorDeUsuarios();

        public void MostrarProductos()
        {
            List<Producto> listaproductos = produ.listarProductos();
            comboBox1.DataSource = listaproductos;
            comboBox1.DisplayMember = "nombre";
        }




        private List<Producto> productos = new List<Producto>();




       








        private void textBoxId_TextChanged(object sender, EventArgs e)
        {

            List<Cliente> listaCli = clie.listarClientes();

            if (int.TryParse(textBox1.Text, out int dni))
            {
                // Buscar la persona con el ID ingresado
                var cliente = listaCli.FirstOrDefault(c => c.dni == dni);
                string idCliente = cliente.id.ToString();
                seleccionidCliente(idCliente);

                if (cliente != null)
                {
                    // Si se encuentra la persona, mostrar el nombre y apellido
                    textBox2.Text = cliente.nombre + " " + cliente.apellido;



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


        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                int indice = dataGridView2.SelectedRows[0].Index;
                productos.RemoveAt(indice);
                Actualizardatagridview();

            }
            else
            {
                MessageBox.Show("Por favor, seleccione un item para eliminar");
            }
        }

        private void Actualizardatagridview()
        {
            var bindingList = new BindingList<Producto>(productos);
            var source = new BindingSource(bindingList, null);
            dataGridView2.DataSource = source;

        }


        public Double CalcularTotal()
        {
            return productos.Sum(p => p.SubTotal);
        }

        public Double CalcularImp()
        {
            return productos.Sum(i => i.impuesto);
        }

        public void seleccionidCliente(string idCliente)
        {
            _idCliente = idCliente;
        }

        public void SeleccionidProducto(string idProducto)
        {
            _idProducto = idProducto;
        }

        public void SeleccionCantidad(int cantidad)
        {
            _cantidad = cantidad;
        }












        private void button1_Click(object sender, EventArgs e)
        {





            textBox7.Text = CalcularTotal().ToString();
            textBox5.Text = CalcularImp().ToString();



















        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Asegurar que no se seleccionen encabezados
            {
                Producto productoSeleccionado = (Producto)dataGridView2.Rows[e.RowIndex].DataBoundItem;

                if (productoSeleccionado != null)
                {
                    RegistrarEvento(productoSeleccionado);
                }
            }
        }

        private void RegistrarEvento(Producto producto)
        {

            _cantidad = producto.cantidad;
            _idProducto = producto.id.ToString();

            //venta.AgregarVenta(_idUsuario, _idCliente, _idProducto, _cantidad);



            //string mensaje = $"Producto seleccionado: {producto.nombre}, Fecha: {DateTime.Now}";
            //MessageBox.Show(mensaje, "Evento Registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Aquí puedes guardar el evento en una lista, archivo o base de datos
        }


        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Obtener la cantidad que se ingresa
            int cantidadProd = int.Parse(textBox10.Text);
            comboBox2.DataSource = Enum.GetNames(typeof(EstadoVenta));

            EstadoVenta estadoSeleccionado = (EstadoVenta)Enum.Parse(typeof(EstadoVenta), comboBox2.SelectedItem.ToString());





            // Obtener el producto seleccionado desde el comboBox
            Producto productoSeleccionado = (Producto)comboBox1.SelectedItem;
            string idProducto = productoSeleccionado.id.ToString();
            SeleccionidProducto(idProducto);

            // Buscar si el producto ya está en la lista de productos
            var productoEnLista = productos.FirstOrDefault(p => p.id == productoSeleccionado.id);

            if (productoEnLista != null)
            {
                // Si el producto ya está en la lista, actualizamos el stock sumando o restando la cantidad ingresada

                //productoSeleccionado.cantidad = productoSeleccionado.cantidad + cantidadProd;
                SeleccionCantidad(productoSeleccionado.cantidad);
                // También actualizamos la cantidad vendida
                productoSeleccionado.stock = productoSeleccionado.stock - cantidadProd;
                string idUser = "70b37dc1-8fde-4840-be47-9ababd0ee7e5";
                Guid idUsuario = Guid.Parse(idUser);
                produ.ModificarProducto(productoSeleccionado.id, idUsuario, productoSeleccionado.precio, productoSeleccionado.stock);
            }
            else
            {
                // Si el producto no está en la lista, lo agregamos
                productoSeleccionado.stock -= cantidadProd; // Resta la cantidad ingresada al stock inicial
                int stockActual = productoSeleccionado.stock;
                productoSeleccionado.cantidad = cantidadProd; // Establecemos la cantidad vendida

                if (stockActual < stockActual * 0.25)
                {
                    MessageBox.Show("El stock está por debajo del 25%");
                }
                else
                {
                    MessageBox.Show("Puede seguir vendiendo");
                }



                // Llamar a la API para persistir el cambio en el stock
                string idUser = "70b37dc1-8fde-4840-be47-9ababd0ee7e5";
                Guid idUsuario = Guid.Parse(idUser);
                produ.ModificarProducto(productoSeleccionado.id, idUsuario, productoSeleccionado.precio, productoSeleccionado.stock);

                // Agregar el producto a la lista
                productos.Add(productoSeleccionado);
            }


            
            // Comprobar si el stock es menor al 25% y mostrar el mensaje adecuado
            

            // Limpiar los campos de entrada
            comboBox1.SelectedIndex = -1;
            textBox10.Clear();

            dataGridView2.AutoGenerateColumns = true;
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = productos;

            dataGridView2.Columns["id"].Visible = false;
            dataGridView2.Columns["fechaAlta"].Visible = false;
            dataGridView2.Columns["fechaBaja"].Visible = false;
            dataGridView2.Columns["idCategoria"].Visible = false;



            // Registrar cada ítem en ventaActual
            Venta ventaActual = new Modelo.Venta
            {
                
                idCliente=_idCliente,             
                idUsuario = _idUsuario,
                idProducto = idProducto,
                cantidad = cantidadProd,
                estado=estadoSeleccionado

            };


            venta.AgregarVenta(ventaActual.idUsuario, ventaActual.idCliente, ventaActual.idProducto, ventaActual.cantidad, DateTime.Now, ventaActual.estado);
            MessageBox.Show("Ítem registrado en venta", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }







    }
}
