using Negocio.Services.Interfaces;
using Negocio.Entities;
using Negocio.Repositories.Interfaces;


namespace Negocio.Services.Implementations
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }
        public async Task<IEnumerable<Producto>> GetAllProductos()
        {
            return await _productoRepository.GetAllProductos();
        }
        public async Task<Producto?> GetProductoById(string codigoBarra)
        {
            return await _productoRepository.GetProductoById(codigoBarra);
        }
        public async Task<Producto> CreateProducto(Producto producto)
        {
            return await _productoRepository.CreateProducto(producto);
        }

        public async Task<Producto> UpdateProducto(Producto producto)
        {
            return await _productoRepository.UpdateProducto(producto);
        }
    }
}
