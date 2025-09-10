using Negocio.DBContext;
using Negocio.Entities;
using Negocio.Models;

namespace Negocio.Services.Interfaces
{
    public interface IVentaService
    {
        Task<Venta> CrearVentaAsync(VentaDTO dto);
        Task<VentaResponseDTO?> ObtenerVentaPorIdAsync(int idVenta);
        Task<List<VentaResponseDTO>> ObtenerVentasDelDiaAsync();


    }
}
