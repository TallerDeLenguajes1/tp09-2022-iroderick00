namespace ProductosJson
{
    internal class Program
    {
        const string nombreArchivoJson = "listadoProductos.json";
        static void Main(string[] args)
        {
            int cantidadDeProductos;
            var listaGenerada = new List<Producto>();
            var listaCargada = new List<Producto>();
            Producto productoAuxiliar;
            Console.WriteLine("Ingrese la cantidad de productos que desea generar: ");
            cantidadDeProductos = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < cantidadDeProductos; i++)
            {
                productoAuxiliar = Producto.generarProductoAleatorio();
                listaGenerada.Add(productoAuxiliar);
            }
            HelperJson.generarJson(nombreArchivoJson, listaGenerada);
            Console.WriteLine("Presione una tecla para avanzar...");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Vamos a presentar una lista de productos cargada de un archivo .json.");
            listaCargada = HelperJson.cargarArchivo(nombreArchivoJson);
            Producto.mostrarProductos(listaCargada);
            }
    }
}