namespace Negocio.Models
{
    public class ResumenMensualDTO
    {
        public int Anio { get; set; }
        public int Mes { get; set; }
        public decimal Ingresos { get; set; }
        public decimal Egresos { get; set; }
        public decimal EgresosCompras { get; set; }
        public decimal EgresosSueldos { get; set; }
        public decimal GananciaNeta { get; set; }
    }
}
