using Negocio.Entities;

namespace Negocio.Repositories.Interfaces
{
    public interface IVentaRepository
    {
        Task<Venta> CrearVentaAsync(Venta venta);
    }
}
