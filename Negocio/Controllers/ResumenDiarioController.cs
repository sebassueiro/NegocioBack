using Microsoft.AspNetCore.Mvc;
using Negocio.Services.Interfaces;

namespace Negocio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResumenDiarioController : ControllerBase
    {
        private readonly IResumenDiarioService _service;

        public ResumenDiarioController(IResumenDiarioService service)
        {
            _service = service;
        }

        [HttpGet("{fecha}")]
        public async Task<IActionResult> GetResumenDiario(DateTime fecha)
        {
            var resumen = await _service.GetArqueoDiarioAsync(fecha);
            return Ok(resumen);
        }
    }
}
