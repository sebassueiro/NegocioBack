using Negocio.DBContext;
using Negocio.Entities;
using Negocio.Models;
using Microsoft.EntityFrameworkCore;
using Negocio.Repositories.Interfaces;

namespace Negocio.Repositories.Implementations
{
    public class PagosEmpleadoRepository : IPagosEmpleadoRepository
    {
        private readonly PuntoVentaContext _context;

        public PagosEmpleadoRepository(PuntoVentaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PagosEmpleadoDTO>> GetAllAsync()
        {
            return await _context.PagosEmpleados
                .Select(p => new PagosEmpleadoDTO
                {
                    IdPagoEmpleado = p.IdPagoEmpleado,
                    IdEmpleado = p.IdEmpleado,
                    Fecha = p.Fecha,
                    Monto = p.Monto
                })
                .ToListAsync();
        }

        public async Task<PagosEmpleadoDTO?> GetByIdAsync(int id)
        {
            return await _context.PagosEmpleados
                .Where(p => p.IdPagoEmpleado == id)
                .Select(p => new PagosEmpleadoDTO
                {
                    IdPagoEmpleado = p.IdPagoEmpleado,
                    IdEmpleado = p.IdEmpleado,
                    Fecha = p.Fecha,
                    Monto = p.Monto
                })
                .FirstOrDefaultAsync();
        }

        public async Task<PagosEmpleadoDTO> AddAsync(PagosEmpleadoDTO pagoDto)
        {
            var entity = new PagosEmpleado
            {
                IdEmpleado = pagoDto.IdEmpleado,
                Fecha = pagoDto.Fecha,
                Monto = pagoDto.Monto
            };

            _context.PagosEmpleados.Add(entity);
            await _context.SaveChangesAsync();

            pagoDto.IdPagoEmpleado = entity.IdPagoEmpleado; // autoincrement
            return pagoDto;
        }

        public async Task<IEnumerable<PagosEmpleadoDTO>> GetByEmpleadoAsync(int idEmpleado)
        {
            return await _context.PagosEmpleados
                .Where(p => p.IdEmpleado == idEmpleado)
                .Select(p => new PagosEmpleadoDTO
                {
                    IdPagoEmpleado = p.IdPagoEmpleado,
                    IdEmpleado = p.IdEmpleado,
                    Fecha = p.Fecha,
                    Monto = p.Monto
                })
                .ToListAsync();
        }

    }
}
