using Microsoft.AspNetCore.Mvc;
using Negocio.Models;
using Negocio.Services.Interfaces;


namespace Negocio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompraController : ControllerBase
    {
        private readonly ICompraService _service;

        public CompraController(ICompraService service)
        {
            _service = service;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var compras = await _service.GetAllAsync();
            return Ok(compras);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var compra = await _service.GetByIdAsync(id);
            if (compra == null) return NotFound();
            return Ok(compra);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CompraDTO dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.IdCompra }, created);
        }
    }
}
