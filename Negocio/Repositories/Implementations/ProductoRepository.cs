using Negocio.DBContext;
using Negocio.Entities;
using Microsoft.EntityFrameworkCore;
using Negocio.Repositories.Interfaces;

namespace Negocio.Repositories.Implementations
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly PuntoVentaContext _puntoVentaContext;
        public ProductoRepository(PuntoVentaContext puntoVentaContext)
        {
            _puntoVentaContext = puntoVentaContext;
        }

        public async Task<IEnumerable<Producto>> GetAllProductos()
        {
            return await _puntoVentaContext.Productos.ToListAsync();
        }
        public async Task<Producto?> GetProductoById(string CodigoBarra)
        {
            return await _puntoVentaContext.Productos.FindAsync(CodigoBarra);
        }
        public async Task<Producto> CreateProducto(Producto producto)
        {
            _puntoVentaContext.Productos.Add(producto);
            await _puntoVentaContext.SaveChangesAsync();
            return producto;
        }
        public async Task<Producto> UpdateProducto(Producto producto)
        {
            _puntoVentaContext.Entry(producto).State = EntityState.Modified;
            await _puntoVentaContext.SaveChangesAsync();
            return producto;
        }
    }
}


    