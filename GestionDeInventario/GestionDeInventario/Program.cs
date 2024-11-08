using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeInventario
{
    class Program
    {
        public static void Main(string[] args)
        {
            Inventario inventario = new Inventario();
            Console.WriteLine("Bienvenido al sistema de gestión de inventario");

            Console.WriteLine("¿Cuántos productos desea ingresar?");
            int cantidad = int.Parse(Console.ReadLine());

            for (int i = 0; i < cantidad; i++)
            {
                Console.WriteLine($"\nProducto {i + 1}");
                Console.Write("Nombre: ");
                string nombre = Console.ReadLine();

                Console.Write("Precio: ");
                double precio = double.Parse(Console.ReadLine());
                
                Producto producto = new Producto(nombre, precio);
                inventario.AgregarProducto(producto);
            }

            Console.Write("\nIngrese el precio minimo para filtrar los productos: ");
            double precioMinimo = double.Parse(Console.ReadLine());

            var productosFiltrados = inventario.FiltrarYOrdenarProductos(precioMinimo);

            Console.WriteLine("\nProductos filtrados y ordenados:");
            foreach (var producto in productosFiltrados)
            {
                Console.WriteLine($"Nombre: {producto.Nombre}, Precio: {producto.Precio}");
            }
        }    
    }
}