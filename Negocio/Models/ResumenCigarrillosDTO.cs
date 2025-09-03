namespace Negocio.Models
{
    public class ResumenCigarrillosDTO
    {
        public decimal TotalCigarrillos { get; set; } // Total vendido en cigarrillos $
        public List<CigarrilloDetalleDTO> Detalles { get; set; } = new();
    }
}

