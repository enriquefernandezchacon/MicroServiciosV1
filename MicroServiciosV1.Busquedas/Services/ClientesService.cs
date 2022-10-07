using MicroServiciosV1.Busquedas.Interfaces;
using MicroServiciosV1.Busquedas.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace MicroServiciosV1.Busquedas.Services
{
    public class ClientesService : IClientesService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ClientesService(IHttpClientFactory httpClientFactory)
        {
             _httpClientFactory = httpClientFactory;
        }
        public async Task<Cliente> GetAsync(string id)
        {
            var clienteHttp = _httpClientFactory.CreateClient("clientesService");

            var respuesta = await clienteHttp.GetAsync($"api/clientes/{id}");

            if (respuesta.IsSuccessStatusCode)
            {
                var content = await respuesta.Content.ReadAsStringAsync();
                var cliente = JsonConvert.DeserializeObject<Cliente>(content);
                return cliente;
            }

            return null;
        }
    }
}
