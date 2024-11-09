using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
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

            Console.WriteLine("¿Cuantos productos desea ingresar?");
            int cantidad;
            while (!int.TryParse(Console.ReadLine(), out cantidad) || cantidad <= 0)
            {
                Console.WriteLine("Número valido, Por favor ingrese un número positivo para la cantidad.");
            }

            for (int i = 0; i < cantidad; i++)
            {
                string nombre;
                double precio;
                do
                {
                    Console.WriteLine($"\nProducto {i + 1}:");
                    nombre = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(nombre))
                    {
                        Console.WriteLine("El nombre del producto no puede estar vacio. Por favor, ingrese de vuelta el nombre");
                    }
                } while (string.IsNullOrWhiteSpace(nombre));

                do
                {
                    Console.WriteLine("Precio");
                    if (!double.TryParse(Console.ReadLine(), out precio) || precio <= 0)
                    {
                        Console.WriteLine("Número invalido, Por favor ingrese un número positivo para el precio");
                    }
                } while (precio <= 0);

                Producto producto = new Producto(nombre, precio);
                inventario.AgregarProducto(producto);
            }

            Console.WriteLine("\nIngrese el precio mínimo para filtrar los productos: ");
            double precioMinimo;
            while (!double.TryParse(Console.ReadLine(), out precioMinimo) || precioMinimo <= 0)
            {
                Console.WriteLine("Por favor, ingrese un precio minimo (mayor o igual a 0)");
            }

            var productosFiltrados = inventario.FiltrarYOrdenarProductos(precioMinimo);

            Console.WriteLine("\nProductos Filtrados y Ordenados:");
            foreach (var producto in productosFiltrados)
            {
                producto.MostrarInfo();
            }

            if (PreguntarUsuario("\n¿Desea actualizar el precio de algún producto? (s/n)"))
            {
                Console.WriteLine("Ingrese un nuevo nombre al producto que desea actualizar");
                string nombreProducto = Console.ReadLine();
                double nuevoPrecio;
                do
                {
                    Console.WriteLine("Ingrese el nuevo precio: ");
                    if (!double.TryParse(Console.ReadLine(), out nuevoPrecio) || nuevoPrecio <= 0)
                    {
                        Console.WriteLine("Por favor, Ingrese un precio positivo");
                    }
                } while (nuevoPrecio <= 0);
                inventario.ActualizarPrecio(nombreProducto,nuevoPrecio);
            }

            if (PreguntarUsuario("\n¿Desea eliminar algún producto? (s/n)"))
            {
                Console.WriteLine("Ingrese el nombre del producto que desea eliminar: ");
                string nombreProductoEliminar = Console.ReadLine();
                inventario.EliminarProducto(nombreProductoEliminar);
            }

            inventario.MostrarReporte();

            static bool PreguntarUsuario(String mensaje)
            {
                string respuesta;
                do
                {
                    Console.WriteLine(mensaje);
                    respuesta = Console.ReadLine().ToLower();
                    if (respuesta != "s" && respuesta != "n")
                    {
                        Console.WriteLine("Por favor, Ingrese s o n para continuar.");
                    }
                } while (respuesta != "s" && respuesta != "n");
                return respuesta == "s";
            }
        }    
    }
}