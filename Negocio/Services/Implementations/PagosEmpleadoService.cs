using Negocio.Models;
using Negocio.Repositories.Interfaces;
using Negocio.Services.Interfaces;

namespace Negocio.Services.Implementations
{
    public class PagosEmpleadoService : IPagosEmpleadoService
    {
        private readonly IPagosEmpleadoRepository _repository;

        public PagosEmpleadoService(IPagosEmpleadoRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<PagosEmpleadoDTO>> GetAllAsync() => _repository.GetAllAsync();
        public Task<PagosEmpleadoDTO?> GetByIdAsync(int id) => _repository.GetByIdAsync(id);
        public Task<PagosEmpleadoDTO> AddAsync(PagosEmpleadoDTO pagoDto) => _repository.AddAsync(pagoDto);
        public Task<IEnumerable<PagosEmpleadoDTO>> GetByEmpleadoAsync(int idEmpleado)
        => _repository.GetByEmpleadoAsync(idEmpleado);

    }
}
