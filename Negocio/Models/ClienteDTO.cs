namespace Negocio.Models
{
    public class ClienteDTO
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Telefono { get; set; }
    }
}
