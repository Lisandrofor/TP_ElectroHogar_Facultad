using Modelo;
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
        
        private ProductosDatos ProductosDatos = new ProductosDatos();
        private List<Categorias> listaCategorias = new List<Categorias>();
        ProductosDatos ProductosDa = new ProductosDatos();
        
        public void AgregarCategoria(int idcategoria, string nomCategoria)
        {

            Categorias lista = new Categorias(idcategoria, nomCategoria);
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

        public List<Categorias> ObtenerCategorias()
        {
            string rutaArchivo = "C:\\Users\\vlisa\\source\\repos\\TP_ElectroHogar_Facultad\\AccesoaDatos\\Categorias.json";

            try
            {
                if (!File.Exists(rutaArchivo))
                {
                    // Si no existe, devuelvo lista vacía
                    return new List<Categorias>();
                }

                string jsonLeer = File.ReadAllText(rutaArchivo);

                if (string.IsNullOrWhiteSpace(jsonLeer))
                {
                    return new List<Categorias>();
                }

                List<Categorias> listaCategorias = JsonConvert.DeserializeObject<List<Categorias>>(jsonLeer);

                if (listaCategorias == null)
                {
                    return new List<Categorias>();
                }

                return listaCategorias;
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error al deserializar el archivo JSON: {ex.Message}");
                return new List<Categorias>();
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error al leer el archivo: {ex.Message}");
                return new List<Categorias>();
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
            Categorias nuevaCategoria = new Categorias(idcategoria, nomCategoria);
            List<Categorias> categorias;

            // Ruta flexible: guarda el JSON junto al ejecutable
            string rutaArchivo = "C:\\Users\\vlisa\\source\\repos\\TP_ElectroHogar_Facultad\\AccesoaDatos\\Categorias.json";

            // Si existe el archivo, leerlo
            if (File.Exists(rutaArchivo))
            {
                string jsonArchivo = File.ReadAllText(rutaArchivo);

                // Si está vacío, crear lista vacía
                if (string.IsNullOrWhiteSpace(jsonArchivo))
                {
                    categorias = new List<Categorias>();
                }
                else if (jsonArchivo.Trim().StartsWith("["))
                {
                    categorias = JsonConvert.DeserializeObject<List<Categorias>>(jsonArchivo);
                }
                else
                {
                    // Caso raro: archivo con una sola categoría guardada como objeto
                    Categorias cat = JsonConvert.DeserializeObject<Categorias>(jsonArchivo);
                    categorias = new List<Categorias> { cat };
                }
            }
            else
            {
                // Si no existe, lista vacía
                categorias = new List<Categorias>();
            }

            // Evitar duplicados: comprobar si ya existe una categoría con el mismo ID
            bool existe = categorias.Any(c => c.IdCategoria == idcategoria);

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



        public void GuardarProductosEliminados(Producto producto,string iduser)
        {

            Producto prodEliminado = new Producto
            {
                id = producto.id,
                nombre = producto.nombre,

            };
            List<Producto> productos;

            // Ruta flexible: guarda el JSON junto al ejecutable
            string rutaArchivo = "C:\\Users\\vlisa\\source\\repos\\TP_ElectroHogar_Facultad\\AccesoaDatos\\ProductosEliminados.json";

            // Si existe el archivo, leerlo
            if (File.Exists(rutaArchivo))
            {
                string jsonArchivo = File.ReadAllText(rutaArchivo);

                // Si está vacío, crear lista vacía
                if (string.IsNullOrWhiteSpace(jsonArchivo))
                {
                    productos = new List<Producto>();
                }
                else if (jsonArchivo.Trim().StartsWith("["))
                {
                    productos = JsonConvert.DeserializeObject<List<Producto>>(jsonArchivo);
                }
                else
                {
                    // Caso raro: archivo con una sola categoría guardada como objeto
                    Producto prod = JsonConvert.DeserializeObject<Producto>(jsonArchivo);
                    productos = new List<Producto> { prod };
                }
            }
            else
            {
                // Si no existe, lista vacía
                productos = new List<Producto>();
            }

            // Evitar duplicados: comprobar si ya existe una categoría con el mismo ID
            bool existe = productos.Any(c => c.id == producto.id);

            if (existe)
            {
                Console.WriteLine($"El producto ya fue eliminado con ID {producto.id}.");
            }
            else
            {
                productos.Add(prodEliminado);

                string nuevoJson = JsonConvert.SerializeObject(productos, Formatting.Indented);
                File.WriteAllText(rutaArchivo, nuevoJson);

                Console.WriteLine("Productos eliminados correctamente.");
            }
        }


        public List<Producto> ObtenerProductosEliminados()
        {
            string rutaArchivo = "C:\\Users\\vlisa\\source\\repos\\TP_ElectroHogar_Facultad\\AccesoaDatos\\ProductosEliminados.json";

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

                List<Producto> listaProductos = JsonConvert.DeserializeObject<List<Producto>>(jsonLeer);

                if (listaProductos == null)
                {
                    return new List<Producto>();
                }

                return listaProductos;
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

            AltaProducto altaProd = new AltaProducto(categoria,idUsuario,idproveedor, nombre,precio,stock);

            try
            {
                ProductosDa.AgregarProd(altaProd);



            }
            catch (Exception ex)
            {
                Console.WriteLine("Error general: " + ex.Message);
            }

        }

        public void ModificarProducto(Guid id, Guid idUsuario, Double precio, int stock)
        {
            ProductosDa.ModificarProducto(id, idUsuario, precio, stock);

        }
        public void BorrarProductos(Producto producto,String idUsuario)
        {
            string id=producto.id.ToString();
            
            ProductosDatos.BorrarProducto(id,idUsuario);
        }


        public void ReactivarProducto(Guid id, string idUsuario)
        {
            ProductosDa.ReactivarProducto(id, idUsuario);

        }



    }
}
