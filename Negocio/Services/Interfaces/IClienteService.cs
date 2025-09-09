using Negocio.Models;

namespace Negocio.Services.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteDTO>> ObtenerTodosAsync();
        Task<ClienteDTO?> ObtenerPorIdAsync(int idCliente);
        Task CrearAsync(CrearClienteDTO dto);
    }
}
