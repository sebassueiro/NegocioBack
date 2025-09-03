namespace Negocio.Models
{
    public class ProductoCreateDTO
    {
        public string CodigoBarra { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioVenta { get; set; }
        public bool EsCigarrillo { get; set; }
        public bool EsPrecioVariable { get; set; }
        
    }
}
