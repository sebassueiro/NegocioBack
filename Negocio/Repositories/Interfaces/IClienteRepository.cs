using Negocio.Entities;

namespace Negocio.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> ObtenerTodosAsync();
        Task<Cliente?> ObtenerPorIdAsync(int idCliente);
        Task CrearAsync(Cliente cliente);
    }
}
