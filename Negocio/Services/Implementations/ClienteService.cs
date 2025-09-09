using Negocio.Entities;
using Negocio.Models;
using Negocio.Repositories.Interfaces;
using Negocio.Services.Interfaces;

namespace Negocio.Services.Implementations
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<ClienteDTO>> ObtenerTodosAsync()
        {
            var clientes = await _clienteRepository.ObtenerTodosAsync();

            return clientes.Select(c => new ClienteDTO
            {
                IdCliente = c.IdCliente,
                Nombre = c.Nombre,
                Telefono = c.Telefono
            });
        }

        public async Task<ClienteDTO?> ObtenerPorIdAsync(int idCliente)
        {
            var cliente = await _clienteRepository.ObtenerPorIdAsync(idCliente);
            if (cliente == null) return null;

            return new ClienteDTO
            {
                IdCliente = cliente.IdCliente,
                Nombre = cliente.Nombre,
                Telefono = cliente.Telefono
            };
        }

        public async Task CrearAsync(CrearClienteDTO dto)
        {
            var cliente = new Cliente
            {
                Nombre = dto.Nombre,
                Telefono = dto.Telefono
            };

            await _clienteRepository.CrearAsync(cliente);
        }
    }
}
