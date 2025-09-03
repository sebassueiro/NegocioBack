using Microsoft.AspNetCore.Mvc;
using Negocio.Models;
using Negocio.Services.Interfaces;

namespace Negocio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentasController : ControllerBase
    {
        private readonly IVentaService _ventaService;

        public VentasController(IVentaService ventaService)
        {
            _ventaService = ventaService;
        }

        [HttpPost]
        public async Task<IActionResult> CrearVenta([FromBody] VentaDTO dto)
        {
            try
            {
                var venta = await _ventaService.CrearVentaAsync(dto);
                return Ok(new { message = "Venta realizada con éxito", venta.IdVenta });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
