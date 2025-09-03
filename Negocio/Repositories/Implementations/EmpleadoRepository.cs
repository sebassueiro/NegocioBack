using Negocio.DBContext;
using Negocio.Entities;
using Negocio.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Negocio.Repositories.Implementations
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly PuntoVentaContext _context;

        public EmpleadoRepository(PuntoVentaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Empleado>> GetAllAsync()
        {
            return await _context.Empleados.ToListAsync();
        }

        public async Task<Empleado?> GetByIdAsync(int id)
        {
            return await _context.Empleados.FindAsync(id);
        }

        public async Task AddAsync(Empleado empleado)
        {
            await _context.Empleados.AddAsync(empleado);
            await _context.SaveChangesAsync();
        }
    }
}
