using Negocio.Models;

namespace Negocio.Services.Interfaces
{
    public interface ICompraService
    {
        Task<IEnumerable<CompraDTO>> GetAllAsync();
        Task<CompraDTO?> GetByIdAsync(int id);
        Task<CompraDTO> CreateAsync(CompraDTO compraDTO);
    }
}
