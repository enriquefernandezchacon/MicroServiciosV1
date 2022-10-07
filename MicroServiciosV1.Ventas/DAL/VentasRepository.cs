using MicroServiciosV1.Ventas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiciosV1.Ventas.DAL
{
    public class VentasRepository : IVentasRepository
    {
        private readonly List<Venta> repo = new List<Venta>();

        public VentasRepository()
        {
            repo.Add(new Venta()
            {
                Id = "0001",
                ClienteId = "1",
                FechaVenta = DateTime.Now.AddMonths(-1),
                Total = 100,
                Elementos = new List<ElementoVenta>()
                {
                    new ElementoVenta() { VentaId = "0001", Id = 1, Precio = 50, ProductoId = "23", Cantidad = 2},
                    new ElementoVenta() { VentaId = "0001", Id = 1, Precio = 50, ProductoId = "23", Cantidad = 2}
                }
            });
            repo.Add(new Venta()
            {
                Id = "0002",
                ClienteId = "2",
                FechaVenta = DateTime.Now.AddMonths(-2),
                Total = 100,
                Elementos = new List<ElementoVenta>()
                {
                    new ElementoVenta(){ VentaId = "0002", Id = 1, Precio = 50, ProductoId = "23", Cantidad = 2},
                    new ElementoVenta(){ VentaId = "0002", Id = 2, Precio = 50, ProductoId = "4", Cantidad = 1}
                }
            });
            repo.Add(new Venta()
            {
                Id = "0003",
                ClienteId = "2",
                FechaVenta = DateTime.Now.AddMonths(-3),
                Total = 100,
                Elementos = new List<ElementoVenta>()
                {
                    new ElementoVenta(){ VentaId = "0003", Id = 1, Precio = 50, ProductoId = "23", Cantidad = 2},
                    new ElementoVenta(){ VentaId = "0003", Id = 2, Precio = 50, ProductoId = "4", Cantidad = 1}
                }
            });
            repo.Add(new Venta()
            {
                Id = "0004",
                ClienteId = "3",
                FechaVenta = DateTime.Now.AddDays(-10),
                Total = 50,
                Elementos = new List<ElementoVenta>()
                {
                    new ElementoVenta(){ VentaId = "0004", Id = 1, Precio = 50, ProductoId = "5", Cantidad = 1}
                }
            });
        }

        public Task<ICollection<Venta>> GetAsync(string clienteId)
        {
            var ventas = repo.Where(c => c.ClienteId == clienteId).ToList();
            return Task.FromResult((ICollection<Venta>) ventas);
        }
    }
}
