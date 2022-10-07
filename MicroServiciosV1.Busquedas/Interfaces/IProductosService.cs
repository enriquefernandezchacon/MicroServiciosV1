using MicroServiciosV1.Busquedas.Models;
using System.Threading.Tasks;

namespace MicroServiciosV1.Busquedas.Interfaces
{
    public interface IProductosService
    {
        Task<Producto> GetAsync(string id);
    }
}
