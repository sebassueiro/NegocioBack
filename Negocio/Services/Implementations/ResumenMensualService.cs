using Negocio.Models;
using Negocio.Repositories.Interfaces;
using Negocio.Services.Interfaces;

namespace Negocio.Services.Implementations
{
    public class ResumenMensualService : IResumenMensualService
    {
        private readonly IResumenMensualRepository _repo;

        public ResumenMensualService(IResumenMensualRepository repo)
        {
            _repo = repo;
        }
        public Task<ResumenMensualDTO> GetResumenMensualAsync(int anio, int mes)
        {
            return _repo.ObtenerResumenMensualAsync(anio, mes);
        }

    }
}
