using Negocio.Models;

namespace Negocio.Services.Interfaces
{
    public interface IEmpleadoService
    {
        Task<IEnumerable<EmpleadoDTO>> GetAllAsync();
        Task<EmpleadoDTO?> GetByIdAsync(int id);
        Task AddAsync(EmpleadoDTO empleadoDto);
    }
}
