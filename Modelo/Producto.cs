using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Modelo
{
    public class Producto
    {
        Guid _id;
        int _idcategoria;
        string _nombreProd;
        DateTime _fechaAlta;
        DateTime _fechaBaja;
        float _precio;
        int _stock;
        string _nomCategoria;

        [JsonConstructor]



        public Producto(int idcategoria, string nomCategoria)
        {
            _idcategoria = idcategoria;
            _nomCategoria = nomCategoria;

        }





        public Producto(Guid id, int idcategoria,string nombreProd, DateTime fechaAlta,DateTime fechaBaja,float precio,int stock)
        {
            _id = id;
            _idcategoria = idcategoria;
            _nombreProd = nombreProd;
            _fechaAlta = fechaAlta;
            _fechaBaja=fechaBaja;
            _precio = precio;
            _stock = stock;



        }


       

        

        

        public Guid id { get => _id; set=> _id=value; }
        public int idCategoria { get=> _idcategoria; set=> _idcategoria=value; }
        public string nomCategoria { get=>_nomCategoria; set=>nomCategoria=value; }
        public string nombreProd { get=> _nombreProd; set=>_nombreProd=value; }
        public DateTime fechaAlta { get=>_fechaAlta; set=>_fechaAlta=value; }
        public DateTime fechaBaja { get=>_fechaBaja; set=>_fechaBaja=value; }
        public float precio { get=>_precio; set=>_precio=value; }
        public int stock { get=>_stock; set=>_stock=value; }



        public override string ToString()
        {
            return $"{idCategoria}  {nomCategoria}";
        }


        






    }
}
