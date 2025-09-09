using Microsoft.AspNetCore.Mvc;
using Negocio.Models;
using Negocio.Services.Interfaces;

namespace Negocio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetClientes()
        {
            var clientes = await _clienteService.ObtenerTodosAsync();
            return Ok(clientes);
        }

        [HttpGet("{idCliente}")]
        public async Task<IActionResult> GetCliente(int idCliente)
        {
            var cliente = await _clienteService.ObtenerPorIdAsync(idCliente);
            if (cliente == null) return NotFound();
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> CrearCliente([FromBody] CrearClienteDTO dto)
        {
            await _clienteService.CrearAsync(dto);
            return Ok(new { message = "Cliente creado con éxito" });
        }
    }
}
