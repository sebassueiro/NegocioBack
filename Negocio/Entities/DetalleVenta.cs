using System;
using System.Collections.Generic;

namespace Negocio.Entities;

public partial class DetalleVenta
{
    public int IdDetalle { get; set; }

    public int IdVenta { get; set; }

    public string CodigoBarra { get; set; }

    public int Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public virtual Producto CodigoBarraNavigation { get; set; } = null!;

    public virtual Venta IdVentaNavigation { get; set; } = null!;
}
