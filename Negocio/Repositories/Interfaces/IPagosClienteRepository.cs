using Negocio.Models;

namespace Negocio.Repositories.Interfaces
{
    public interface IPagosClienteRepository
    {
        Task<int> RegistrarMovimientoAsync(PagosClienteDTO movimiento);
        Task<IEnumerable<PagosClienteDTO>> ObtenerPagosPorClienteAsync(int idCliente);
    }
}
