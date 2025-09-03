
namespace Negocio.Models
{
    public class VentaDTO
    {
        public int? IdCliente { get; set; }
        public int? IdEmpleado { get; set; }
        public bool EsFiado { get; set; }
        public decimal Total { get; set; }
        public List<DetalleVentaDTO> Detalle { get; set; }
    }
}
