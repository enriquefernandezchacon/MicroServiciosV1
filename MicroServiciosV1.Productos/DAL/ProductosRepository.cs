using MicroServiciosV1.Productos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiciosV1.Productos.DAL
{
    public class ProductosRepository : IProductosRepository
    {
        private List<Producto> repo = new List<Producto>();

        public ProductosRepository()
        {
            for (int i = 0; i < 100; i++)
            {
                repo.Add(new Producto()
                {
                    Id = (i + 1).ToString(),
                    Nombre = $"Praoducto {i + 1}",
                    Precio = (double)i * Math.PI
                });
            }
        }
        public Task<Producto> GetAsync(string id)
        {
            var product = repo.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(product);
        }
    }
}
