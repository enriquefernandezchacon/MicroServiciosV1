using MicroServiciosV1.Clientes.Models;
using System.Threading.Tasks;

namespace MicroServiciosV1.Clientes.DAL
{
    public interface IClientesRepository
    {
        Task<Cliente> GetAsync(string id);
    }
}
