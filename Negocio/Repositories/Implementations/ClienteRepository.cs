using Microsoft.EntityFrameworkCore;
using Negocio.DBContext;
using Negocio.Entities;
using Negocio.Repositories.Interfaces;

namespace Negocio.Repositories.Implementations
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly PuntoVentaContext _context;

        public ClienteRepository(PuntoVentaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> ObtenerTodosAsync()
        {
            return await _context.Clientes
                .Include(c => c.PagosClientes)
                .ToListAsync();
        }

        public async Task<Cliente?> ObtenerPorIdAsync(int idCliente)
        {
            return await _context.Clientes
                .Include(c => c.PagosClientes)
                .FirstOrDefaultAsync(c => c.IdCliente == idCliente);
        }

        public async Task CrearAsync(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
        }
    }
}
