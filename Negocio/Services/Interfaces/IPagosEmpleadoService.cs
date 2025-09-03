using Negocio.Models;

namespace Negocio.Services.Interfaces
{
    public interface IPagosEmpleadoService
    {
        Task<IEnumerable<PagosEmpleadoDTO>> GetAllAsync();
        Task<PagosEmpleadoDTO?> GetByIdAsync(int id);
        Task<PagosEmpleadoDTO> AddAsync(PagosEmpleadoDTO pagoDto);
        Task<IEnumerable<PagosEmpleadoDTO>> GetByEmpleadoAsync(int idEmpleado);

    }
}
