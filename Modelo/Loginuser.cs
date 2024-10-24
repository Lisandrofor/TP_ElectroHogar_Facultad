using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Loginuser
    {
        private string _nombreUsuario;
        private string _contraseña;
        private string _contraseñaNueva;
        private int _valor;
        private static Dictionary<string, int> _conteoIng = new Dictionary<string, int>();



        public string NombreUsuario { get => _nombreUsuario; set => _nombreUsuario = value; }
        public string Contraseña { get => _contraseña; set => _contraseña = value; }

        public string ContraseñaNueva { get => _contraseñaNueva; set => _contraseñaNueva = value; }

        public int valor { get => _valor; set => _valor = value; }

        public Dictionary<string,int> conteoIng { get => _conteoIng; set => _conteoIng = value; }


        public Loginuser(string nombreUsuario, string contraseña)
        {

            this.NombreUsuario = nombreUsuario;
            this.Contraseña = contraseña;
            ContraseñaNueva = string.Empty;
        }

        public Loginuser(string nombreUsuario, string contraseña, string contraseñanueva)
        {
            this.NombreUsuario = nombreUsuario;
            this.Contraseña = contraseña;
            this.ContraseñaNueva = contraseñanueva;
        }



        public bool IngresosUsuario(string idUsuario, string nombreUsuario, string contraseña)
        {
            string claveBuscada = idUsuario;
            int valor;

            if (!conteoIng.ContainsKey(idUsuario))
            {
                valor = 1;
                conteoIng.Add(idUsuario,valor); // El primer intento cuenta como 1, no 0
                return false; // Primer ingreso, no ha alcanzado el conteo límite
            }
            else 
            {
                if (conteoIng.TryGetValue(claveBuscada, out valor))
                {
                    if (valor > 1)
                    {

                        return true;
                    }
                    else
                    {
                        // Si el usuario ya está en el diccionario, incrementamos el conteo
                        conteoIng[claveBuscada]++;
                        return false;

                        // Si el conteo es 1 o más, devolvemos true (lo que indica que ya ha ingresado antes)

                    }


                }

                return true;
            }
           













           
        }



        


    }


}
  

   
        

    
    
    
    





