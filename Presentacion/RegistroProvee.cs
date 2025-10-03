using Modelo;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class RegistroProvee : Form
    {
        public RegistroProvee()
        {
            InitializeComponent();
            MostrarCategorias();
        }

        GestordeProductos gestorCategoria = new GestordeProductos();

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            GestordeProveedores gestorProvee = new GestordeProveedores();


            string nombre = textBox2.Text;
            string apellido = textBox3.Text;
            string cuit = textBox10.Text;
            string direccion = textBox4.Text;
            string email = textBox6.Text;
            string telefono = textBox11.Text;
            string categoria = comboBox1.DisplayMember;
            
           





            gestorProvee.ValidarNombre(nombre);
            gestorProvee.ValidarApellido(apellido);


            try
            {
                // Llamada al método AgregarUsuario con los parámetros adecuados
                gestorProvee.AgregarProveedor(nombre, apellido, cuit, direccion, telefono,email,categoria);

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

        public void MostrarCategorias()
        {
            List<Categorias> lista = gestorCategoria.ObtenerCategorias();
            comboBox1.DataSource = lista;
            comboBox1.DisplayMember = "nomCategoria" + "idCategoria";

        }

        
    }
}
