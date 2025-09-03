using Negocio.Models;
using Negocio.Repositories.Interfaces;
using Negocio.Services.Interfaces;

namespace Negocio.Services.Implementations
{
    public class CompraService : ICompraService
    {
        private readonly ICompraRepository _repo;

        public CompraService(ICompraRepository repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<CompraDTO>> GetAllAsync() => _repo.GetAllAsync();

        public Task<CompraDTO?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);

        public Task<CompraDTO> CreateAsync(CompraDTO compraDTO) => _repo.CreateAsync(compraDTO);
    }
}
