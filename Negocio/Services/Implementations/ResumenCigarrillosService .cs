using Negocio.Models;
using Negocio.Repositories.Interfaces;
using Negocio.Services.Interfaces;

namespace Negocio.Services.Implementations
{
    public class ResumenCigarrillosService : IResumenCigarrillosService
    {
        private readonly IResumenCigarrillosRepository _repository;

        public ResumenCigarrillosService(IResumenCigarrillosRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResumenCigarrillosDTO> GetCigarrillosVendidosAsync(DateTime fecha)
        {
            return await _repository.ObtenerCigarrillosVendidosAsync(fecha);
        }
    }
}
