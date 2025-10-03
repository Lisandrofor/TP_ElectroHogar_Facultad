using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Categorias
    {
        int _idcategoria;
        string _nomCategoria;


        public Categorias(int id, string nombre)
        {
            IdCategoria = id;
            NomCategoria = nombre;
        }


        public int IdCategoria { get=>_idcategoria; set=>_idcategoria=value; }
        public string NomCategoria { get=>_nomCategoria; set=>_nomCategoria=value; }


        public string Mostrar => $"{IdCategoria} - {NomCategoria}";


    }

}
