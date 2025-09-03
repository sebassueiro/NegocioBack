using Negocio.DBContext;
using Negocio.Entities;
using Negocio.Models;
using Negocio.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Negocio.Repositories.Implementations
{
    public class CompraRepository : ICompraRepository
    {
        private readonly PuntoVentaContext _context;

        public CompraRepository(PuntoVentaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CompraDTO>> GetAllAsync()
        {
            return await _context.Compras
                .Include(c => c.IdProveedorNavigation)
                .Select(c => new CompraDTO
                {
                    IdCompra = c.IdCompra,
                    IdProveedor = c.IdProveedor,
                    Fecha = c.Fecha,
                    Total = c.Total,
                    NombreProveedor = c.IdProveedorNavigation.Nombre
                })
                .ToListAsync();
        }

        public async Task<CompraDTO?> GetByIdAsync(int id)
        {
            var compra = await _context.Compras
                .Include(c => c.IdProveedorNavigation)
                .FirstOrDefaultAsync(c => c.IdCompra == id);

            if (compra == null) return null;

            return new CompraDTO
            {
                IdCompra = compra.IdCompra,
                IdProveedor = compra.IdProveedor,
                Fecha = compra.Fecha,
                Total = compra.Total,
                NombreProveedor = compra.IdProveedorNavigation.Nombre
            };
        }

        public async Task<CompraDTO> CreateAsync(CompraDTO compraDTO)
        {
            var entity = new Compra
            {
                IdProveedor = compraDTO.IdProveedor,
                Fecha = compraDTO.Fecha,
                Total = compraDTO.Total
            };

            _context.Compras.Add(entity);
            await _context.SaveChangesAsync();

            compraDTO.IdCompra = entity.IdCompra;
            return compraDTO;
        }
    }
}
