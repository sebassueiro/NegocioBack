namespace Negocio.Models
{
    public class DetalleVentaResponseDTO
    {
        public string CodigoBarra { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}
