using Negocio.Models;
using Negocio.Repositories.Interfaces;
using Negocio.Services.Interfaces;

namespace Negocio.Services.Implementations
{
    public class ProveedorService : IProveedorService
    {
        private readonly IProveedorRepository _repo;

        public ProveedorService(IProveedorRepository repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<ProveedorDTO>> GetAllAsync() => _repo.GetAllAsync();
        public Task<ProveedorDTO?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task<ProveedorDTO> CreateAsync(ProveedorDTO proveedorDTO) => _repo.CreateAsync(proveedorDTO);
    }

}
