using Negocio.Entities;
using Negocio.Models;

namespace Negocio.Services.Interfaces
{
    public interface IVentaService
    {
        Task<Venta> CrearVentaAsync(VentaDTO dto);
    }
}
