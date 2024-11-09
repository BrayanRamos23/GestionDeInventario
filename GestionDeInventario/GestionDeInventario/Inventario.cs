using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeInventario
{
    public class Inventario
    {
        private List<Producto> productos;

        public Inventario()
        {
            productos = new List<Producto>();
        }

        public void AgregarProducto(Producto producto)
        {
            productos.Add(producto);
        }

        public void ActualizarPrecio(string nuevoNombre, double nuevoPrecio)
        {
            Producto producto = productos.FirstOrDefault(p => p.Nombre == nuevoNombre);

            if (producto != null)
            {
                producto.Precio = nuevoPrecio;
                Console.WriteLine($"Producto actualizado: {producto.Nombre}, Nuevo Precio: C${producto.Precio}");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }

        public void EliminarProducto(string nombre)
        {

            Producto producto = productos.FirstOrDefault(p => p.Nombre == nombre);

            if (producto != null)
            {
                productos.Remove(producto);
                Console.WriteLine($"Producto eliminado: {producto.Nombre}");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }

        public void MostrarReporte()
        {
            int totalProductos = productos.Count;

            double precioPromedio = productos.Any() ? productos.Average(p => p.Precio) : 0;

            var productosOrdenados = productos.OrderByDescending(p => p.Precio).ToList();

            Console.WriteLine("===== Reporte de Inventario =====");
            Console.WriteLine($"Número total de productos: {totalProductos}");
            Console.WriteLine($"Precio promedio de los productos: C${precioPromedio:F2}");
            Console.WriteLine("Productos de mayor a menor precio:");

            foreach (var producto in productosOrdenados)
            {
                Console.WriteLine($"- {producto.Nombre}: C${producto.Precio}");
            }
        }


        public IEnumerable<Producto> FiltrarYOrdenarProductos(double precioMinimo)
        {
            return productos.Where(p => p.Precio > precioMinimo).OrderBy(p => p.Precio);
        }
    }
}
