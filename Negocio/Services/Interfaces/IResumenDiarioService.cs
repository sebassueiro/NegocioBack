using Negocio.Models;

namespace Negocio.Services.Interfaces
{
    public interface IResumenDiarioService
    {
        Task<ResumenDiarioDTO> GetArqueoDiarioAsync(DateTime? fecha = null);
    }
}
