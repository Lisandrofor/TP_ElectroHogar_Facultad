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
        private List<Impuesto> lista;


        public Ventas(string idUsuario)
        {
            InitializeComponent();
            MostrarProductos();

            _idUsuario = idUsuario;




        }





private Venta _venta;
private VentaDTO _ventaDTO;

private void FormVenta_Load(object sender, EventArgs e)
{
    _venta = new Venta();
      _ventaDTO = new VentaDTO();
            dataGridView2.CellValueChanged += dataGridView2_CellValueChanged_1;
            dataGridView2.CurrentCellDirtyStateChanged += dataGridView2_CurrentCellDirtyStateChanged_1;

            GestordeImpuestos imp = new GestordeImpuestos();
            lista = imp.ObtenerImpuestos();

            ConfigurarGrilla();
            dataGridView2.DataSource = items;
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





        private BindingList<VentaItems> items = new BindingList<VentaItems>();















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
                items.RemoveAt(indice);
                Actualizardatagridview();

                decimal total = items.Sum(i => i.Total);

                textBox7.Text = total.ToString();
            }

        
            else
            {
                MessageBox.Show("Por favor, seleccione un item para eliminar");
            }
        }

        private void Actualizardatagridview()
        {
            var bindingList = new BindingList<VentaItems>(items);
            var source = new BindingSource(bindingList, null);
            dataGridView2.DataSource = source;

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
            var existente = items.FirstOrDefault(p => p.IdProducto == producto.id);

            if (existente != null)
            {
                existente.Cantidad += cantidad;
                return; // 🔥 IMPORTANTE
            }

            var imp = lista.FirstOrDefault(i => i.Id == producto.IdImpuesto);

            if (imp == null)
            {
                imp = lista.First();
                producto.IdImpuesto = imp.Id;
            }

            VentaItems nuevo = new VentaItems(producto.id,producto.nombre, cantidad, producto.precio, imp);
            nuevo.Impue.Id = producto.IdImpuesto;
            items.Add(nuevo);
            _venta.AgregarItem(nuevo);
            venta.AgregarVenta(
                _idUsuario,
                _idCliente,
                producto.id.ToString(),
                cantidad,
                DateTime.Now,
                ObtenerEstadoVenta()
            );
            var ventaDTO = new VentaDTO
            {
                idUsuario = _venta.idUsuario,
                idCliente = _venta.idCliente,
                estado = _venta.estado,
                items = _venta.Items
            };
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


        





        private void ConfigurarGrilla()
        {
            

        

            

           
            dataGridView2.AutoGenerateColumns = false;

            // 🔹 Nombre
            dataGridView2.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Nombre",
                HeaderText = "Nombre"
            });

            // 🔹 Precio
            dataGridView2.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "precio",
                HeaderText = "Precio"
            });

            // 🔹 Cantidad
            dataGridView2.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Cantidad",
                HeaderText = "Cantidad"
            });

            
            

            // 🔹 Subtotal (Precio * Cantidad)
            dataGridView2.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Subtotal", // Debe existir como propiedad calculada
                HeaderText = "Subtotal",
                ReadOnly = true
            });

            DataGridViewComboBoxColumn colImpuesto = new DataGridViewComboBoxColumn();
            colImpuesto.Name = "colImpuesto";   // 🔥 agregar esto
            colImpuesto.HeaderText = "Impuesto";
            colImpuesto.DataSource = lista;
            colImpuesto.DisplayMember = "Nombre";
            colImpuesto.ValueMember = "Id";
            colImpuesto.DataPropertyName = "Impuesto";

            dataGridView2.Columns.Add(colImpuesto);

            // 🔹 Total (Subtotal + Impuesto)
            dataGridView2.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Total", // Debe existir como propiedad calculada
                HeaderText = "Total",
                ReadOnly = true
            });


            dataGridView2.DataSource = items;




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
            Impuesto impuesto = producto.impuesto;

        }

        private void dataGridView2_CellValueChanged_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.Columns[e.ColumnIndex].Name == "colImpuesto")
            {
                VentaItems ventanueva = (VentaItems)dataGridView2.Rows[e.RowIndex].DataBoundItem;

                if (ventanueva != null)
                {

                    ventanueva.Impue = lista.FirstOrDefault(i => i.Id == ventanueva.Impue.Id);

                    items.ResetItem(e.RowIndex);
                }
            }

        }



        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!DatosValidos()) return;

            int cantidad = ObtenerCantidad();
            Producto producto = ObtenerProductoSeleccionado();
            

            EstadoVenta estado = ObtenerEstadoVenta();
            _venta.estado = estado;

            
            



          
            
            

           

            ActualizarProductoEnLista(producto, cantidad);
            ActualizarStock(producto, cantidad);
            PersistirStock(producto);
            



        }

        






        private void button1_Click(object sender, EventArgs e)
        {
            _venta.idUsuario = _idUsuario;
            _venta.idCliente = _idCliente;
            _venta.fechaAlta = DateTime.Now;



            decimal subtotal = _venta.Subtotal;
            decimal impuestos = _venta.Impuestos;
            decimal totalFinal = _venta.Total;

            venta.GuardarVentas(_ventaDTO);

            textBox4.Text = subtotal.ToString();
            textBox5.Text = impuestos.ToString();
            textBox7.Text = totalFinal.ToString();

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

        private void dataGridView2_CurrentCellDirtyStateChanged_1(object sender, EventArgs e)
        {
            if (dataGridView2.IsCurrentCellDirty)
            {
                dataGridView2.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }

        }

       
    }
}
