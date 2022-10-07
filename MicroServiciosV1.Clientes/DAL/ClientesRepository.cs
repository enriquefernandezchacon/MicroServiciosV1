using MicroServiciosV1.Clientes.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiciosV1.Clientes.DAL
{
    public class ClientesRepository : IClientesRepository
    {
        private readonly List<Cliente> repo = new List<Cliente>();

        public ClientesRepository()
        {
            repo.Add(new Cliente() { Id = "1", Nombre = "Enrique", City = "Almeria"});
            repo.Add(new Cliente() { Id = "2", Nombre = "Maria", City = "Almeria" });
            repo.Add(new Cliente() { Id = "3", Nombre = "Guillermo", City = "Granada" });
            repo.Add(new Cliente() { Id = "4", Nombre = "Juan", City = "Jaen" });
        }
        public Task<Cliente> GetAsync(string id)
        {
            var cliente = repo.FirstOrDefault(c => c.Id == id);
            return Task.FromResult(cliente);
        }
    }
}
