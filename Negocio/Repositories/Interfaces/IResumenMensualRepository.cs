using Negocio.Models;

namespace Negocio.Repositories.Interfaces
{
    public interface IResumenMensualRepository
    {
        Task<ResumenMensualDTO> ObtenerResumenMensualAsync(int anio, int mes);
    }
}
