using MySqlConnector;
using Negocio.Models;
using Negocio.Repositories.Interfaces;
using Negocio.Services.Interfaces;

namespace Negocio.Services.Implementations
{
    public class PagosClienteService : IPagosClienteService
    {
        private readonly IPagosClienteRepository _repository;

        public PagosClienteService(IPagosClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> RegistrarMovimientoAsync(PagosClienteDTO pago)
        {
            return await _repository.RegistrarMovimientoAsync(pago);
        }

        public async Task<IEnumerable<PagosClienteDTO>> ObtenerPagosPorClienteAsync(int idCliente)
        {
            return await _repository.ObtenerPagosPorClienteAsync(idCliente);
        }
    }
}
