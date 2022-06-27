using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductosJson
{
    public class Producto
    {
        public Producto()
        {
        }
        public string nombre { get; set; }
        public DateTime fechaVencimiento { get; set; }
        private float precio;
        public float Precio 
        {
            get => precio;
            set
            {
                if (value >= 1000 && value <= 5000)
                {
                    precio = value;
                }
            }
        }
        public string tamanio { get; set; }
        public Producto(string nombre, DateTime fechaVencimiento, float precio, string tamanio)
        {
            this.nombre = nombre;
            this.fechaVencimiento = fechaVencimiento;
            this.precio = precio;
            this.tamanio = tamanio;
        }
        public enum nombres
        {
            galletas,
            alfajor,
            gaseosa,
            caramelos,
            papitas,
        }
        public enum enumTamanio
        {
            grande,
            mediano,
            chico,
        }
        public static Producto generarProductoAleatorio()
        {
            var nuevoProducto = new Producto();
            nuevoProducto.nombre = ((nombres)new Random().Next(5)).ToString();
            nuevoProducto.fechaVencimiento = DateTime.Today.AddYears(2);
            nuevoProducto.precio = new Random().Next(1000, 5000);
            nuevoProducto.tamanio = ((enumTamanio)new Random().Next(3)).ToString();
            return nuevoProducto;
        }
        public static void mostrarProductos(List<Producto> lista)
        {
            Console.WriteLine("------------------LISTA DE PRODUCTOS------------------");
            foreach (var producto in lista)
            {
                Console.WriteLine($"Tipo de producto: {producto.nombre}");
                Console.WriteLine($"Fecha de vencimiento: {producto.fechaVencimiento}");
                Console.WriteLine($"Precio: ${producto.Precio}");
                Console.WriteLine($"Tamano: {producto.tamanio}");
            }
            Console.WriteLine("------------------FIN DE LISTA------------------");
        }
    }
}
