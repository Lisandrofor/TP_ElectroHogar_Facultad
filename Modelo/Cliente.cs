﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Cliente
    {

        Guid _id;
        string _nombre;
        string _apellido;
        int _dni;
        string _direccion;
        string _telefono;
        string _email;
        DateTime _fechaNacimiento;
        DateTime _fechaAlta;
        DateTime? _fechaBaja = null;
        string _host;
        


        public Cliente()
        {
        }



        public Cliente(Guid id, string nombre, string apellido, int dni,string direccion,string telefono,string email, DateTime fechaNacimiento,DateTime fechaAlta,DateTime fechaBaja, string host)
        {
            _id = id;
            _nombre = nombre;
            _apellido = apellido;
            _dni = dni;
            _direccion = direccion;
            _telefono = telefono;
            _email= email;
            _fechaNacimiento = fechaNacimiento;
            _fechaAlta= fechaAlta;  
            _fechaBaja= fechaBaja;
            _host = host;
            

        }

        public Guid id { get => _id; set => _id = value; }

        public string nombre { get => _nombre; set => _nombre = value; }
        public string apellido { get => _apellido; set => _apellido = value; }
        public int dni { get => _dni; set => _dni = value; }
        public string direccion { get => _direccion; set => _direccion = value; }
        public string telefono { get => _telefono; set => _telefono = value; }
        public string email { get => _email; set => _email = value; }
       
        public DateTime fechaNacimiento { get => _fechaNacimiento; set => _fechaNacimiento = value; }
        public DateTime fechaAlta { get => _fechaAlta; set => _fechaAlta = value; }
        public DateTime? fechaBaja { get => _fechaBaja; set => _fechaBaja = value; }

       
        public string host { get => _host; set => _host = value; }


        


        





        public override String ToString()
        {
            return this.apellido + ", " + this.nombre + " (" + this.dni + ")";
        }



    }
}