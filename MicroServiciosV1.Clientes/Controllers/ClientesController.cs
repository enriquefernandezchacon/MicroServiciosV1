using MicroServiciosV1.Clientes.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MicroServiciosV1.Clientes.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClientesRepository clientesRepository;
        public ClientesController(IClientesRepository clientesRepository)
        {
            this.clientesRepository = clientesRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var cliente = await clientesRepository.GetAsync(id);

            if (cliente != null) { return Ok(cliente); }

            return NotFound();
        }
    }
}
