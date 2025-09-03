using System;
using System.Collections.Generic;

namespace Negocio.Entities;

public partial class Proveedores
{
    public int IdProveedor { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();
}
