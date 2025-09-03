using Negocio.Entities;

namespace Negocio.Services.Interfaces
{
    public interface IProductoService
    {
        Task<IEnumerable<Producto>> GetAllProductos();
        Task<Producto?> GetProductoById(string codigoBarra);
        Task<Producto> CreateProducto(Producto producto);
        Task<Producto> UpdateProducto(Producto producto);
    }
}
