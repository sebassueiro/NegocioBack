using Negocio.Models;

namespace Negocio.Services.Interfaces
{
    public interface IResumenMensualService
    {
        Task<ResumenMensualDTO> GetArqueoMensualAsync(int? anio = null, int? mes = null);
    }
}
