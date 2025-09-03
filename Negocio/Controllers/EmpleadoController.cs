using Microsoft.AspNetCore.Mvc;
using Negocio.Models;
using Negocio.Services.Interfaces;

namespace Negocio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleadoService _empleadoService;

        public EmpleadoController(IEmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

        [HttpGet("getAllEmpleado")]
        public async Task<ActionResult<IEnumerable<EmpleadoDTO>>> GetAll()
        {
            var empleados = await _empleadoService.GetAllAsync();
            return Ok(empleados);
        }

        [HttpGet("getEmpleado/{id}")]
        public async Task<ActionResult<EmpleadoDTO>> GetById(int id)
        {
            var empleado = await _empleadoService.GetByIdAsync(id);
            if (empleado == null) return NotFound();
            return Ok(empleado);
        }

        [HttpPost("createEmpleado")]
        public async Task<ActionResult> Add(EmpleadoDTO empleadoDto)
        {
            await _empleadoService.AddAsync(empleadoDto);
            return CreatedAtAction(nameof(GetById), new { id = empleadoDto.IdEmpleado }, empleadoDto);
        }
    }
}
