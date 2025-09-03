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
    }
}
