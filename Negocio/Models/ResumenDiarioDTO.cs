namespace Negocio.Models
{
    public class ResumenDiarioDTO
    {
        public DateTime Fecha { get; set; }
        public decimal Ingresos { get; set; }
        public decimal Egresos { get; set; }
        public decimal GananciaNeta { get; set; }
    }
}
