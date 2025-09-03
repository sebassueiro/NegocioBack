using Negocio.Entities;
using Negocio.Models;

namespace Negocio.Repositories.Interfaces
{
    public interface IResumenDiarioRepository
    {
        Task<ResumenDiarioDTO> GenerarYObtenerArqueoDiarioAsync(DateTime fecha);
    }
}
