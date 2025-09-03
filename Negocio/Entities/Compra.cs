using System;
using System.Collections.Generic;

namespace Negocio.Entities;

public partial class Compra
{
    public int IdCompra { get; set; }

    public int IdProveedor { get; set; }

    public DateTime Fecha { get; set; }

    public decimal Total { get; set; }

    public virtual Proveedores IdProveedorNavigation { get; set; } = null!;
}
