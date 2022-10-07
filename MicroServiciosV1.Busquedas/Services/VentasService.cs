using MicroServiciosV1.Busquedas.Interfaces;
using MicroServiciosV1.Busquedas.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MicroServiciosV1.Busquedas.Services
{
    public class VentasService : IVentasService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public VentasService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<ICollection<Venta>> GetAsync(string clienteId)
        {
            var clienteHttp = _httpClientFactory.CreateClient("ventasService");
            var respuesta = await clienteHttp.GetAsync($"api/ventas/{clienteId}");
            if (respuesta.IsSuccessStatusCode)
            {
                var content = await respuesta.Content.ReadAsStringAsync();
                var ventas = JsonConvert.DeserializeObject<ICollection<Venta>>(content);
                return ventas;
            }
            return null;
        }
    }
}
