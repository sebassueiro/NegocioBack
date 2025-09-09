using Negocio.Models;

namespace Negocio.Services.Interfaces
{
    public interface IPagosClienteService
    {
        Task<int> RegistrarMovimientoAsync(PagosClienteDTO movimiento);
        Task<IEnumerable<PagosClienteDTO>> ObtenerPagosPorClienteAsync(int idCliente);
    }
}
