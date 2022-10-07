using MicroServiciosV1.Busquedas.Interfaces;
using MicroServiciosV1.Busquedas.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace MicroServiciosV1.Busquedas.Services
{
    public class ProductosService : IProductosService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ProductosService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<Producto> GetAsync(string id)
        {
            var clienteHttp = _httpClientFactory.CreateClient("productosService");
            var respuesta = await clienteHttp.GetAsync($"api/productos/{id}");
            if (respuesta.IsSuccessStatusCode)
            {
                var content = await respuesta.Content.ReadAsStringAsync();
                var producto = JsonConvert.DeserializeObject<Producto>(content);
                return producto;
            }
            return null;
        }
    }
}
