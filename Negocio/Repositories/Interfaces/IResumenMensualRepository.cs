using Negocio.Models;

namespace Negocio.Repositories.Interfaces
{
    public interface IResumenMensualRepository
    {
        Task<ResumenMensualDTO> GenerarYObtenerArqueoMensualAsync(int anio, int mes);
    }
}
