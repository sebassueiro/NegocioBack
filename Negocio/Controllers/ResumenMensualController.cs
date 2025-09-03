using Microsoft.AspNetCore.Mvc;
using Negocio.Services.Interfaces;

namespace Negocio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResumenMensualController : ControllerBase
    {
        private readonly IResumenMensualService _service;

        public ResumenMensualController(IResumenMensualService service)
        {
            _service = service;
        }

        [HttpGet("{anio}/{mes}")]
        public async Task<IActionResult> GetResumenMensual(int anio, int mes)
        {
            var resumen = await _service.GetArqueoMensualAsync(anio, mes);
            return Ok(resumen);
        }
    }
}
