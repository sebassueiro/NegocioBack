namespace Negocio.Models
{
    public class PagosEmpleadoDTO
    {
        public int IdPagoEmpleado { get; set; }
        public int IdEmpleado { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
    }
}
