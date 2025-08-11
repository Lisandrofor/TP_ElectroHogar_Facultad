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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Presentacion
{
    public partial class RegistroCateg : Form
    {
        public RegistroCateg()
        {
            InitializeComponent();
            MostrarCategorias();    
        }


        GestordeProductos gestorCategoria = new GestordeProductos();
        private void btnRegistrar_Click(object sender, EventArgs e)
        {

            


            string nomCategoria = textBox2.Text;
            int idCategoria = int.Parse(textBox3.Text);
            





            //gestorCliente1.ValidarNombre(nombre);
            //gestorCliente1.ValidarApellido(apellido);




            try
            {
                // Llamada al método AgregarUsuario con los parámetros adecuados
                gestorCategoria.AgregarCategoria(idCategoria, nomCategoria);
                gestorCategoria.GuardarCategorias(idCategoria, nomCategoria);

                
            }
            catch (ArgumentNullException ex)
            {
                // Captura la excepción si alguno de los argumentos es null
                Console.WriteLine("Error: Uno de los argumentos es nulo.");
                Console.WriteLine(ex.Message);
            }

            





















            BorrarCampos();
            MessageBox.Show($"Categoria Agregada Exitosamente");

        }

        public void MostrarCategorias()
        {
            List<Producto> lista = gestorCategoria.ObtenerCategorias();
            comboBox1.DataSource = lista;
            comboBox1.DisplayMember = "nomCategoria";
            comboBox1.ValueMember = "idCategoria";

        }

        private void BorrarCampos()
        {
            textBox2.Clear();
            textBox3.Clear();
            

        }



    }


}


