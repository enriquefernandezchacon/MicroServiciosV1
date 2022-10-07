using MicroServiciosV1.Ventas.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiciosV1.Ventas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private readonly IVentasRepository ventasRepository;

        public VentasController(IVentasRepository ventasRepository)
        {
            this.ventasRepository = ventasRepository;
        }


        // GET api/values
        [HttpGet("{clienteId}")]
        public async Task<IActionResult> GetAsync(string clienteId) 
        {
            var ventas = await ventasRepository.GetAsync(clienteId);

            if (ventas != null && ventas.Any()) 
            { 
                return Ok(ventas);  

            }

            return NotFound();
        }

    }
}
