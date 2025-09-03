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
        public Task<ResumenMensualDTO> GetArqueoMensualAsync(int? anio = null, int? mes = null)
        {
            var now = DateTime.Now;
            var a = anio ?? now.Year;
            var m = mes ?? now.Month;
            return _repo.GenerarYObtenerArqueoMensualAsync(a, m);
        }

    }
}
