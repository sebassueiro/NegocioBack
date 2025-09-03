using Negocio.Models;

namespace Negocio.Repositories.Interfaces
{
    public interface IPagosEmpleadoRepository
    {
        Task<IEnumerable<PagosEmpleadoDTO>> GetAllAsync();
        Task<PagosEmpleadoDTO?> GetByIdAsync(int id);
        Task<PagosEmpleadoDTO> AddAsync(PagosEmpleadoDTO pagoDto);
        Task<IEnumerable<PagosEmpleadoDTO>> GetByEmpleadoAsync(int idEmpleado);

    }
}
