namespace Negocio.Models
{
    public class PagosClienteDTO
    {
        public int IdPago { get; set; }
        public int IdCliente { get; set; }
        public DateTime Fecha { get; set; }
        public int Monto { get; set; }   // Único campo numérico que mandamos
        public string Tipo { get; set; } = null!; // "DEUDA" o "PAGO"
        public int Saldo { get; set; }   // El saldo actualizado después de la operación
    }
}
