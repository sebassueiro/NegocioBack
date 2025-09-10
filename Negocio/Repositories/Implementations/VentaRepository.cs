using Microsoft.EntityFrameworkCore;
using Negocio.DBContext;
using Negocio.Entities;
using Negocio.Repositories.Interfaces;

namespace Negocio.Repositories.Implementations
{
    public class VentaRepository : IVentaRepository
    {
        private readonly PuntoVentaContext _puntoVentaContext;

        public VentaRepository(PuntoVentaContext puntoVentaContext)
        {
            _puntoVentaContext = puntoVentaContext;
        }

        public async Task<Venta> CrearVentaAsync(Venta venta)
        {
            _puntoVentaContext.Ventas.Add(venta);
            await _puntoVentaContext.SaveChangesAsync();
            return venta;
        }
        public async Task<Venta?> ObtenerVentaPorIdAsync(int idVenta)
        {
            return await _puntoVentaContext.Ventas
                .Include(v => v.DetalleVenta)
                .ThenInclude(d => d.CodigoBarraNavigation) // para traer el nombre del producto
                .FirstOrDefaultAsync(v => v.IdVenta == idVenta);
        }
        public async Task<List<Venta>> ObtenerVentasDelDiaAsync()
        {
            var hoy = DateTime.Today;

            return await _puntoVentaContext.Ventas
                .Include(v => v.DetalleVenta)
                .ThenInclude(d => d.CodigoBarraNavigation)
                .Where(v => v.Fecha.Date == hoy) // solo las de hoy
                .OrderByDescending(v => v.Fecha) // de la última a la primera
                .ToListAsync();
        }

    }
}
