using System;
using System.Collections.Generic;

namespace Negocio.Entities;

public partial class Producto
{
    public string CodigoBarra { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal PrecioVenta { get; set; }

    public bool EsCigarrillo { get; set; }
    public bool EsPrecioVariable { get; set; }

    public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();
}
