using Microsoft.AspNetCore.Mvc;
using Negocio.Models;
using Negocio.Services.Interfaces;

namespace Negocio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PagosClienteController : ControllerBase
    {
        private readonly IPagosClienteService _service;

        public PagosClienteController(IPagosClienteService service)
        {
            _service = service;
        }

        [HttpPost("deuda")]
        public async Task<IActionResult> RegistrarDeuda([FromBody] PagosClienteDTO deuda)
        {
            deuda.Tipo = "DEUDA";
            deuda.Fecha = DateTime.Now;

            var id = await _service.RegistrarMovimientoAsync(deuda);
            return Ok(new { IdPago = id, Tipo = "DEUDA" });
        }

        [HttpPost("pago")]
        public async Task<IActionResult> RegistrarPago([FromBody] PagosClienteDTO pago)
        {
            pago.Tipo = "PAGO";
            pago.Fecha = DateTime.Now;

            var id = await _service.RegistrarMovimientoAsync(pago);
            return Ok(new { IdPago = id, Tipo = "PAGO" });
        }

        [HttpGet("cliente/{idCliente}")]
        public async Task<IActionResult> ObtenerPagosPorCliente(int idCliente)
        {
            var pagos = await _service.ObtenerPagosPorClienteAsync(idCliente);
            return Ok(pagos);
        }
    }
}
