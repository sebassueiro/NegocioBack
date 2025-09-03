using Negocio.Models;

namespace Negocio.Services.Interfaces
{
    public interface IProveedorService
    {
        Task<IEnumerable<ProveedorDTO>> GetAllAsync();
        Task<ProveedorDTO?> GetByIdAsync(int id);
        Task<ProveedorDTO> CreateAsync(ProveedorDTO proveedor);
    }
}
