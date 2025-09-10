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
            public async Task<VentaResponseDTO?> ObtenerVentaPorIdAsync(int idVenta)
            {
                var venta = await _ventaRepository.ObtenerVentaPorIdAsync(idVenta);
                if (venta == null) return null;

                return new VentaResponseDTO
                {
                    IdVenta = venta.IdVenta,
                    Fecha = venta.Fecha,
                    Total = venta.Total,
                    EsFiado = venta.EsFiado,
                    Detalle = venta.DetalleVenta.Select(d => new DetalleVentaResponseDTO
                    {
                        CodigoBarra = d.CodigoBarra,
                        Nombre = d.CodigoBarraNavigation?.Nombre ?? string.Empty,
                        Cantidad = d.Cantidad,
                        PrecioUnitario = d.PrecioUnitario
                    }).ToList()
                };
            }
        public async Task<List<VentaResponseDTO>> ObtenerVentasDelDiaAsync()
        {
            var ventas = await _ventaRepository.ObtenerVentasDelDiaAsync();

            return ventas.Select(venta => new VentaResponseDTO
            {
                IdVenta = venta.IdVenta,
                Fecha = venta.Fecha,
                Total = venta.Total,
                EsFiado = venta.EsFiado,
                Detalle = venta.DetalleVenta.Select(d => new DetalleVentaResponseDTO
                {
                    CodigoBarra = d.CodigoBarra,
                    Nombre = d.CodigoBarraNavigation?.Nombre ?? string.Empty,
                    Cantidad = d.Cantidad,
                    PrecioUnitario = d.PrecioUnitario
                }).ToList()
            }).ToList();
        }

    }
}
