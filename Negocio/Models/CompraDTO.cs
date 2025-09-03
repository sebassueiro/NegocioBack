namespace Negocio.Models
{
    public class CompraDTO
    {
        public int IdCompra { get; set; }        // solo lectura
        public int IdProveedor { get; set; }     // FK
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }

        public string? NombreProveedor { get; set; }
    }
}
