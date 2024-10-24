using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Presentacion
{
    internal class ValidadorUtils
    {


        public void validarTexto(string texto, string campo)
        {
            string msgError = "";
            msgError = msgError + validarVacio(texto, campo) + "/n";

            MessageBox.Show(msgError);
        }

        private string validarVacio(string texto, string campo)
        {
            if (texto.Length == 0)
            {
               
                return "El campo " + campo + " no puede estar vacio";
            }
            return "";
        }

        //private Boolean validarVacio(string vacio)
        //{
        
        
        //  }

    }
}
