using Microsoft.EntityFrameworkCore;
using Negocio.DBContext;
using Negocio.Entities;
using Negocio.Models;
using Negocio.Repositories.Interfaces;

namespace Negocio.Repositories.Implementations
{
    public class ProveedorRepository : IProveedorRepository
    {
        private readonly PuntoVentaContext _context;

        public ProveedorRepository(PuntoVentaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProveedorDTO>> GetAllAsync()
        {
            return await _context.Proveedores
                .Select(p => new ProveedorDTO
                {
                    IdProveedor = p.IdProveedor,
                    Nombre = p.Nombre,
                    Descripcion = p.Descripcion
                }).ToListAsync();
        }

        public async Task<ProveedorDTO?> GetByIdAsync(int id)
        {
            var proveedor = await _context.Proveedores.FindAsync(id);
            if (proveedor == null) return null;

            return new ProveedorDTO
            {
                IdProveedor = proveedor.IdProveedor,
                Nombre = proveedor.Nombre,
                Descripcion = proveedor.Descripcion
            };
        }

        public async Task<ProveedorDTO> CreateAsync(ProveedorDTO proveedorDTO)
        {
            var entity = new Proveedores
            {
                Nombre = proveedorDTO.Nombre,
                Descripcion = proveedorDTO.Descripcion
            };

            _context.Proveedores.Add(entity);
            await _context.SaveChangesAsync();

            // 👇 EF carga el Id autoincrementado en entity.IdProveedor
            proveedorDTO.IdProveedor = entity.IdProveedor;

            return proveedorDTO;
        }
    }
}
