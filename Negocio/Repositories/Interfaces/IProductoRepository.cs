using Negocio.Entities;

namespace Negocio.Repositories.Interfaces
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> GetAllProductos();
        Task<Producto?> GetProductoById(string codigoBarra);
        Task<Producto> CreateProducto(Producto producto);
        Task<Producto> UpdateProducto(Producto producto);
    }
}
