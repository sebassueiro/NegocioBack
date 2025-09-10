namespace Negocio.Models
{
    public class VentaResponseDTO
    {
        public int IdVenta { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public bool? EsFiado { get; set; }
        public List<DetalleVentaResponseDTO> Detalle { get; set; }
    }
}
