using Negocio.Models;

namespace Negocio.Services.Interfaces
{
    public interface IResumenMensualService
    {
        Task<ResumenMensualDTO> GetResumenMensualAsync(int anio, int mes);
    }
}
