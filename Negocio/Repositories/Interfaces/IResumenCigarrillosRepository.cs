using Negocio.Models;

namespace Negocio.Repositories.Interfaces
{
    public interface IResumenCigarrillosRepository
    {
        Task<ResumenCigarrillosDTO> ObtenerCigarrillosVendidosAsync(DateTime fecha);
    }
}
