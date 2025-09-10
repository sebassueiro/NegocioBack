using Negocio.Entities;

namespace Negocio.Repositories.Interfaces
{
    public interface IVentaRepository
    {
        Task<Venta> CrearVentaAsync(Venta venta);
        Task<Venta?> ObtenerVentaPorIdAsync(int idVenta);
        Task<List<Venta>> ObtenerVentasDelDiaAsync();
    }
}
