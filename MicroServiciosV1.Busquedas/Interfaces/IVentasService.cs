using MicroServiciosV1.Busquedas.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroServiciosV1.Busquedas.Interfaces
{
    public interface IVentasService
    {
        Task<ICollection<Venta>> GetAsync(string clienteId);
    }
}
