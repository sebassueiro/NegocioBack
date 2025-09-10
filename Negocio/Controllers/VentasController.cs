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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVentaById(int id)
        {
            try
            {
                var venta = await _ventaService.ObtenerVentaPorIdAsync(id);
                if (venta == null)
                    return NotFound(new { message = "Venta no encontrada" });

                return Ok(venta);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
        [HttpGet("hoy")]
        public async Task<IActionResult> GetVentasDelDia()
        {
            try
            {
                var ventas = await _ventaService.ObtenerVentasDelDiaAsync();
                return Ok(ventas);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

    }
}
