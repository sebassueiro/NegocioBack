using Microsoft.EntityFrameworkCore;
using Negocio.DBContext;
using Negocio.Entities;
using Negocio.Models;
using Negocio.Repositories.Interfaces;

namespace Negocio.Repositories.Implementations
{
    public class ResumenCigarrillosRepository : IResumenCigarrillosRepository
    {
        private readonly PuntoVentaContext _puntoVentaContext;

        public ResumenCigarrillosRepository(PuntoVentaContext puntoVentaContext)
        {
            _puntoVentaContext = puntoVentaContext;
        }

        public async Task<ResumenCigarrillosDTO> ObtenerCigarrillosVendidosAsync(DateTime fecha)
        {
            var query = from v in _puntoVentaContext.Set<Venta>()
                        join dv in _puntoVentaContext.Set<DetalleVenta>() on v.IdVenta equals dv.IdVenta
                        join p in _puntoVentaContext.Set<Producto>() on dv.CodigoBarra equals p.CodigoBarra
                        where v.Fecha.Date == fecha.Date && p.EsCigarrillo
                        group new { dv, p } by new { p.Nombre, dv.PrecioUnitario } into g
                        select new CigarrilloDetalleDTO
                        {
                            Nombre = g.Key.Nombre,
                            Cantidad = g.Sum(x => x.dv.Cantidad),
                            PrecioUnitario = g.Key.PrecioUnitario
                        };

            var detalles = await query.ToListAsync();

            return new ResumenCigarrillosDTO
            {
                TotalCigarrillos = detalles.Sum(d => d.Total),
                Detalles = detalles
            };
        }
    }
}
