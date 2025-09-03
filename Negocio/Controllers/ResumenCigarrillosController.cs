using Microsoft.AspNetCore.Mvc;
using Negocio.Services.Interfaces;

namespace Negocio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResumenCigarrillosController : ControllerBase
    {
        private readonly IResumenCigarrillosService _service;

        public ResumenCigarrillosController(IResumenCigarrillosService service)
        {
            _service = service;
        }

        [HttpGet("{fecha}")]
        public async Task<IActionResult> GetResumen(DateTime fecha)
        {
            var resumen = await _service.GetCigarrillosVendidosAsync(fecha);
            return Ok(resumen);
        }
    }
}
