using MicroServiciosV1.Ventas.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroServiciosV1.Ventas.DAL
{
    public interface IVentasRepository
    {
        Task<ICollection<Venta>> GetAsync(string clienteId);
            
    }
}
