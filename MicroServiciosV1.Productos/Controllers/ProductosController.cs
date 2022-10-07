using MicroServiciosV1.Productos.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MicroServiciosV1.Productos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProductosRepository _productosRepository;

        public ProductosController(IProductosRepository productosRepository)
        {
            _productosRepository = productosRepository;
        }
    
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var result = await _productosRepository.GetAsync(id);

            if (result != null) {
                return Ok(result);
            }

            return NotFound();
        }
    }
}
