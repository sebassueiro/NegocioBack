using Negocio.Entities;
using Negocio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Negocio.Services.Implementations;
using Negocio.Models;

namespace Negocio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet("getAllProductos")]
        public async Task<ActionResult<IEnumerable<Producto>>> GetAllProductos()
        {
            try
            {
                var productos = await _productoService.GetAllProductos();
                return Ok(productos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener los productos: {ex.Message}");
            }
        }

        [HttpGet("getProducto/{codigoBarra}")]
        public async Task<ActionResult<Producto>> GetProducto(string codigoBarra)
        {
            try
            {
                var producto = await _productoService.GetProductoById(codigoBarra);
                if (producto == null)
                {
                    return NotFound($"No se encontró el producto con ese codigo de barra {codigoBarra}");
                }
                return Ok(producto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener el producto: {ex.Message}");
            }
        }

        [HttpPost("createProducto")]
        public async Task<ActionResult<Producto>> CreateProducto([FromBody] ProductoCreateDTO productoCreateDTO)
        {
            try
            {
                var producto = new Producto
                {
                    CodigoBarra = productoCreateDTO.CodigoBarra,
                    Nombre = productoCreateDTO.Nombre,
                    Descripcion = productoCreateDTO.Descripcion,
                    PrecioVenta = productoCreateDTO.PrecioVenta,
                    EsCigarrillo = productoCreateDTO.EsCigarrillo,
                    EsPrecioVariable = productoCreateDTO.EsPrecioVariable
                };

                var createdProducto = await _productoService.CreateProducto(producto);
                return CreatedAtAction(nameof(GetProducto), new { CodigoBarra = createdProducto.CodigoBarra }, createdProducto);
            }
            catch (Exception ex)
            {
                var inner = ex.InnerException != null ? ex.InnerException.Message : "";
                return StatusCode(500, $"Error al crear el producto: {ex.Message} {inner}");
            }

        }

        [HttpPut("updateProducto/{codigoBarra}")]
        public async Task<IActionResult> UpdateProducto(string codigoBarra, [FromBody] ProductoUpdateDTO productoupdateDTO)
        {
            try
            {
                var producto = await _productoService.GetProductoById(codigoBarra);
                if (producto == null)
                {
                    return NotFound($"No se encontró el producto con el codigo de barra {codigoBarra}");
                }

                producto.PrecioVenta = productoupdateDTO.PrecioVenta;

                await _productoService.UpdateProducto(producto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar el producto: {ex.Message}");
            }
        }

    }
}
