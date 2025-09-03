using Negocio.Models;

namespace Negocio.Services.Interfaces
{
    public interface IResumenCigarrillosService
    {
        Task<ResumenCigarrillosDTO> GetCigarrillosVendidosAsync(DateTime fecha);
    }
}
