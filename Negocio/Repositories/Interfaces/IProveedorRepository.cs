using Negocio.Models;

namespace Negocio.Repositories.Interfaces
{
    public interface IProveedorRepository
    {
        Task<IEnumerable<ProveedorDTO>> GetAllAsync();
        Task<ProveedorDTO?> GetByIdAsync(int id);
        Task<ProveedorDTO> CreateAsync(ProveedorDTO proveedor);
    }
}
