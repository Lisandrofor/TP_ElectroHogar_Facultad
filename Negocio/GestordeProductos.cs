﻿using Modelo;
using AccesoaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;


namespace Negocio
{
    public class GestordeProductos
    {
        
        
        private List<Producto> listaCategorias = new List<Producto>();
        ProductosDatos ProductosDa = new ProductosDatos();
        
        public void AgregarCategoria(int idcategoria, string nomCategoria)
        {

            Producto lista = new Producto(idcategoria, nomCategoria);
            listaCategorias.Add(lista);
        }

        public List<Producto> ObtenerProdporCategorias(int idcategoria) 
        {
            return ProductosDa.getProductosporCat(idcategoria);
        
        
        }

        public List<Producto> listarProductos()
        {
            return ProductosDa.getProductos();
        }

        public List<Producto> ObtenerCategorias()
        {
            string rutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Categorias.json");

            try
            {
                if (!File.Exists(rutaArchivo))
                {
                    // Si no existe, devuelvo lista vacía
                    return new List<Producto>();
                }

                string jsonLeer = File.ReadAllText(rutaArchivo);

                if (string.IsNullOrWhiteSpace(jsonLeer))
                {
                    return new List<Producto>();
                }

                List<Producto> listaCategorias = JsonConvert.DeserializeObject<List<Producto>>(jsonLeer);

                if (listaCategorias == null)
                {
                    return new List<Producto>();
                }

                return listaCategorias;
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error al deserializar el archivo JSON: {ex.Message}");
                return new List<Producto>();
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error al leer el archivo: {ex.Message}");
                return new List<Producto>();
            }
        }






        //public List<Producto> ObtenerCategorias()
        //{
        //    string rutaArchivo = "C:\\Users\\Usuario\\source\\repos\\TPCAI_Electro\\AccesoaDatos\\Categorias.json";
        //    try
        //    {
        //        string jsonLeer = File.ReadAllText(rutaArchivo);
        //        List<Producto> listaCategorias = JsonConvert.DeserializeObject<List<Producto>>(jsonLeer);

        //        if (listaCategorias == null)
        //        {
        //            listaCategorias = new List<Producto>(); // Retorna una lista vacía si el archivo estaba vacío o no se pudo deserializar
        //        }

        //        return listaCategorias;
        //    }
        //    catch (JsonException ex)
        //    {
        //        Console.WriteLine($"Error al deserializar el archivo JSON: {ex.Message}");
        //        return new List<Producto>(); // Retorna una lista vacía en caso de error
        //    }
        //    catch (IOException ex)
        //    {
        //        Console.WriteLine($"Error al leer el archivo: {ex.Message}");
        //        return new List<Producto>(); // Retorna una lista vacía en caso de error
        //    }
        //}
        public void GuardarCategorias(int idcategoria, string nomCategoria)
        {
            // Nueva categoría
            Producto nuevaCategoria = new Producto(idcategoria, nomCategoria);
            List<Producto> categorias;

            // Ruta flexible: guarda el JSON junto al ejecutable
            string rutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Categorias.json");

            // Si existe el archivo, leerlo
            if (File.Exists(rutaArchivo))
            {
                string jsonArchivo = File.ReadAllText(rutaArchivo);

                // Si está vacío, crear lista vacía
                if (string.IsNullOrWhiteSpace(jsonArchivo))
                {
                    categorias = new List<Producto>();
                }
                else if (jsonArchivo.Trim().StartsWith("["))
                {
                    categorias = JsonConvert.DeserializeObject<List<Producto>>(jsonArchivo);
                }
                else
                {
                    // Caso raro: archivo con una sola categoría guardada como objeto
                    Producto cat = JsonConvert.DeserializeObject<Producto>(jsonArchivo);
                    categorias = new List<Producto> { cat };
                }
            }
            else
            {
                // Si no existe, lista vacía
                categorias = new List<Producto>();
            }

            // Evitar duplicados: comprobar si ya existe una categoría con el mismo ID
            bool existe = categorias.Any(c => c.idCategoria == idcategoria);

            if (existe)
            {
                Console.WriteLine($"La categoría con ID {idcategoria} ya existe.");
            }
            else
            {
                categorias.Add(nuevaCategoria);

                string nuevoJson = JsonConvert.SerializeObject(categorias, Formatting.Indented);
                File.WriteAllText(rutaArchivo, nuevoJson);

                Console.WriteLine("Categoría guardada correctamente.");
            }
        }











        //public void GuardarCategorias(int idcategoria, string nomCategoria)
        //{
        //    Producto categoria = new Producto(idcategoria, nomCategoria);
        //    List<Producto> categorias;

        //    string rutaArchivo = "C:\\Users\\Usuario\\source\\repos\\TPCAI_Electro\\AccesoaDatos\\Categorias.json";

        //    if (File.Exists(rutaArchivo))
        //    {
        //        // Deserializamos el contenido del archivo en una lista de objetos Producto
        //        string jsonArchivo = File.ReadAllText(rutaArchivo);
        //        try
        //        {
        //            categorias = JsonConvert.DeserializeObject<List<Producto>>(jsonArchivo);
        //        }
        //        catch (JsonSerializationException)
        //        {
        //            // Si falla, intentar deserializar como un solo objeto y convertirlo en una lista
        //            categoria = JsonConvert.DeserializeObject<Producto>(jsonArchivo);
        //            categorias = new List<Producto> { categoria };
        //        }

               
        //    }
        //    else
        //    {
        //        // Si el archivo no existe, inicializamos una nueva lista
        //        categorias = new List<Producto>();
        //    }

        //    // Agregamos la nueva categoría a la lista
        //    categorias.Add(categoria);

        //    // Serializamos la lista completa de categorías y escribimos en el archivo
        //    string nuevojson = JsonConvert.SerializeObject(categorias, Formatting.Indented);
        //    File.WriteAllText(rutaArchivo, nuevojson);
        //}

        public void AgregarProd(int categoria, string idproveedor,string nombre, float precio, int stock)
        {
            //string idUsuario = Guid.NewGuid().ToString();
            string idUsuario = "70b37dc1-8fde-4840-be47-9ababd0ee7e5";

            AltaProducto altaProd = new AltaProducto(categoria,idproveedor,idUsuario, nombre,precio,stock);

            try
            {
                ProductosDa.AgregarProd(altaProd);



            }
            catch (Exception ex)
            {
                Console.WriteLine("Error general: " + ex.Message);
            }

        }

        public void ModificarProducto(Guid id, Guid idUsuario, float precio, int stock)
        {
            ProductosDa.ModificarProducto(id, idUsuario, precio, stock);

        }



    }
}
