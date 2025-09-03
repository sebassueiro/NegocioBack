using Negocio.Entities;
using Negocio.Models;
using Negocio.Repositories.Interfaces;
using Negocio.Services.Interfaces;

namespace Negocio.Services.Implementations
{
    public class VentaService : IVentaService
    {
        private readonly IVentaRepository _ventaRepository;

        public VentaService(IVentaRepository ventaRepository)
        {
            _ventaRepository = ventaRepository;
        }

        public async Task<Venta> CrearVentaAsync(VentaDTO dto)
        {
            // 🔎 Validación: recalcular total
            decimal totalCalculado = dto.Detalle.Sum(d => d.PrecioUnitario * d.Cantidad);
            if (dto.Total != totalCalculado)
            {
                throw new Exception("El total no coincide con el detalle de la venta");
            }

            var venta = new Venta
            {
                Fecha = DateTime.Now,
                IdCliente = dto.IdCliente,
                IdEmpleado = dto.IdEmpleado,
                Total = dto.Total,
                EsFiado = dto.EsFiado,
                DetalleVenta = dto.Detalle.Select(d => new DetalleVenta
                {
                    CodigoBarra = d.CodigoBarra,
                    Cantidad = d.Cantidad,
                    PrecioUnitario = d.PrecioUnitario
                }).ToList()
            };

            return await _ventaRepository.CrearVentaAsync(venta);
        }
    }
}
