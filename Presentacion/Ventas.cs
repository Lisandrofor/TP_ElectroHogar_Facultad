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

private Venta _venta;

private void FormVenta_Load(object sender, EventArgs e)
{
    _venta = new Venta();
}


        Cliente cliente = new Cliente();
        GestordeClientes clie = new GestordeClientes();
        GestordeProductos produ = new GestordeProductos();
        GestordeVentas venta = new GestordeVentas();
        GestorDeUsuarios user = new GestorDeUsuarios();
        Venta ventaModel = new Venta();


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
                   
                    venta.seleccionidCliente(idCliente);


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


        //public decimal CalcularSubTotal()
        //{
        //    return productos.Sum(p => p.SubTotal);
        //}

        //public decimal CalcularImp()
        //{
        //    return productos.Sum(i => i.ImporteImpuesto);
        //}

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


        


        private bool DatosValidos()
        {
            if (comboBox1.SelectedItem == null || string.IsNullOrWhiteSpace(textBox10.Text))
            {
                MessageBox.Show("Seleccione producto y cantidad.");
                return false;
            }
            return true;
        }

        private int ObtenerCantidad() => int.Parse(textBox10.Text);

        private Producto ObtenerProductoSeleccionado()
        {
            return (Producto)comboBox1.SelectedItem;
        }


        private EstadoVenta ObtenerEstadoVenta()
        {
            comboBox2.DataSource = Enum.GetNames(typeof(EstadoVenta));
            return (EstadoVenta)Enum.Parse(typeof(EstadoVenta), comboBox2.SelectedItem.ToString());
        }


        private void ActualizarProductoEnLista(Producto producto, int cantidad)
        {
            var existente = productos.FirstOrDefault(p => p.id == producto.id);

            if (existente != null)
            {
                existente.cantidad += cantidad;
            }
            else
            {
                producto.cantidad = cantidad;
                productos.Add(producto);
            }
        }


        private void ActualizarStock(Producto producto, int cantidad)
        {
            
            producto.stock -= cantidad;
            

            if (cantidad > producto.stock * 0.25)
                MessageBox.Show("El stock está por debajo del 25%");

        }

        private void PersistirStock(Producto producto)
        {
            Guid idUsuario = Guid.Parse("70b37dc1-8fde-4840-be47-9ababd0ee7e5");
            produ.ModificarProducto(producto.id, idUsuario, producto.precio, producto.stock);
        }


        private void ActualizarGrilla()
        {
            dataGridView2.DataSource = null;
            dataGridView2.AutoGenerateColumns = true;
            dataGridView2.DataSource = productos;

            dataGridView2.Columns["id"].Visible = false;
            dataGridView2.Columns["fechaAlta"].Visible = false;
            dataGridView2.Columns["fechaBaja"].Visible = false;
            dataGridView2.Columns["idCategoria"].Visible = false;
        }


        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!DatosValidos()) return;

            int cantidad = ObtenerCantidad();
            Producto producto = ObtenerProductoSeleccionado();
            EstadoVenta estado = ventaModel.estado = ObtenerEstadoVenta();
             RegistrarVenta(producto.id.ToString(), cantidad, estado);

VentaItem item = new VentaItem
    {
        Producto = productoSeleccionado,
        Cantidad = cantidad,
        PrecioUnitario = productoSeleccionado.Precio
    };

_venta.AgregarItem(item);

            ActualizarProductoEnLista(producto, cantidad);
            ActualizarStock(producto, cantidad);
            PersistirStock(producto);
            ActualizarGrilla();



        }

        






        private void button1_Click(object sender, EventArgs e)
        {



            textBox4.Text = ventaModel.Subtotal().ToString();
            textBox5.Text = ventaModel.TotalImpuestos().ToString();
            textBox6.Text = CalculaDescuento().ToString();

            decimal totalFinal = ventaModel.Subtotal() + ventaModel.TotalImpuestos() - CalculaDescuento();
            textBox7.Text =totalFinal.ToString();





            MostrarResumenVenta(totalFinal);
            LimpiarFormulario();















        }


        private void RegistrarVenta(string idProducto, int cantidad, EstadoVenta estado)
        {
            venta.AgregarVenta(
                _idUsuario,
                _idCliente,
                idProducto,
                cantidad,
                DateTime.Now,
                estado
            );
ventaModel.agregaritems(VentaItems items)
        }

       


        private void MostrarResumenVenta(decimal total)
        {
            MessageBox.Show($"Total final: {total:C}", "Venta registrada");
        }

        private void LimpiarFormulario()
        {
            comboBox1.SelectedIndex = -1;
            textBox10.Clear();
        }










    }
}
