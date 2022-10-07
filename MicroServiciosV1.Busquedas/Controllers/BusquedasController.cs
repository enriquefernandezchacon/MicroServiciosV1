using MicroServiciosV1.Busquedas.Interfaces;
using MicroServiciosV1.Busquedas.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiciosV1.Busquedas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusquedasController : ControllerBase
    {
        private readonly IClientesService _clientesService;
        private readonly IProductosService _productosService;
        private readonly IVentasService _ventasService;
        public BusquedasController(IClientesService clientesService, IProductosService productosService, IVentasService ventasService)
        {
            _clientesService = clientesService;
            _productosService = productosService;
            _ventasService = ventasService;
        }

        // GET api/values/5
        [HttpGet("clientes/{clienteId}")]
        public async Task<ActionResult> SearchAsync(string clienteId)
        {
            if (string.IsNullOrWhiteSpace(clienteId))
            {
                return BadRequest();
            }

            try
            {
                var cliente = await _clientesService.GetAsync(clienteId);

                var ventas = await _ventasService.GetAsync(clienteId);

                foreach (var venta in ventas)
                {
                    foreach (var item in venta.Elementos)
                    {
                        var product = await _productosService.GetAsync(item.ProductoId);

                        item.Product = product;
                    }
                }

                var result = new
                {
                    Cliente = cliente,
                    Venta = ventas
                };

                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
