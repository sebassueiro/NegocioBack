using Negocio.Models;
using Negocio.Repositories.Interfaces;
using Negocio.Services.Interfaces;

namespace Negocio.Services.Implementations
{
    public class ResumenDiarioService : IResumenDiarioService
    {
        private readonly IResumenDiarioRepository _repo;

        public ResumenDiarioService(IResumenDiarioRepository repo)
        {
            _repo = repo;
        }

        public Task<ResumenDiarioDTO> GetArqueoDiarioAsync(DateTime? fecha = null)
        {
            var f = (fecha ?? DateTime.Now).Date;
            return _repo.GenerarYObtenerArqueoDiarioAsync(f);
        }
    }
}
