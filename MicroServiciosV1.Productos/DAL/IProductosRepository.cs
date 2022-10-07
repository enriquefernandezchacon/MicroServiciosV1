using MicroServiciosV1.Productos.Models;
using System.Threading.Tasks;

namespace MicroServiciosV1.Productos.DAL
{
    public interface IProductosRepository
    {
        Task<Producto> GetAsync(string id);
    }
}
