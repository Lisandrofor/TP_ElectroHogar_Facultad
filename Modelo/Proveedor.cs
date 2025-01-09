using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Proveedor
    {
        Guid _id;
        string _nombre;
        string _apellido;
        string _email;
        string _cuit;
        DateTime _fechaAlta=DateTime.Now;
        DateTime? _fechaBaja;
        
       
       
        
        


        public Proveedor()
        {
        }



        public Proveedor(Guid id, string nombre, string apellido, string Cuit)
        {
            
            _id = id;
            _nombre = nombre;
            _apellido = apellido;
            _cuit = Cuit;
            
            
           

        }

        public Guid id { get => _id; set => _id = value; }
       
        

        public string nombre { get => _nombre; set => _nombre = value; }
        public string apellido { get => _apellido; set => _apellido = value; }
        public string CUIT { get => _cuit; set => _cuit = value; }
        public string email { get => _email; set => _email = value; }
        
        
        public DateTime fechaAlta { get => _fechaAlta; set => _fechaAlta = value; }
        public DateTime? fechaBaja { get => _fechaBaja; set => _fechaBaja = value; }

        
        


        


        
       





        public override string ToString()
        {
            return $"{nombre}";
        }


    }
}
