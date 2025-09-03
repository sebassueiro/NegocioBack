using Microsoft.AspNetCore.Mvc;
using Negocio.Models;
using Negocio.Services.Interfaces;

namespace Negocio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PagosEmpleadoController : ControllerBase
    {
        private readonly IPagosEmpleadoService _service;

        public PagosEmpleadoController(IPagosEmpleadoService service)
        {
            _service = service;
        }

        [HttpGet("getPagosEmpleados")]
        public async Task<ActionResult<IEnumerable<PagosEmpleadoDTO>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("getPagoEmpleado/{id}")]
        public async Task<ActionResult<PagosEmpleadoDTO>> GetById(int id)
        {
            var pago = await _service.GetByIdAsync(id);
            if (pago == null) return NotFound();
            return Ok(pago);
        }

        [HttpPost("createPagoEmpleado")]
        public async Task<ActionResult<PagosEmpleadoDTO>> Add(PagosEmpleadoDTO pagoDto)
        {
            var created = await _service.AddAsync(pagoDto);
            return CreatedAtAction(nameof(GetById), new { id = created.IdPagoEmpleado }, created);
        }

        [HttpGet("empleado/{idEmpleado}")]
        public async Task<ActionResult<IEnumerable<PagosEmpleadoDTO>>> GetByEmpleado(int idEmpleado)
        {
            var pagos = await _service.GetByEmpleadoAsync(idEmpleado);
            if (pagos == null || !pagos.Any()) return NotFound();
            return Ok(pagos);
        }


    }
}
