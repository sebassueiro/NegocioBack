using Negocio.Models;

namespace Negocio.Repositories.Interfaces
{
    public interface ICompraRepository
    {
        Task<IEnumerable<CompraDTO>> GetAllAsync();
        Task<CompraDTO?> GetByIdAsync(int id);
        Task<CompraDTO> CreateAsync(CompraDTO compraDTO);
    }
}
