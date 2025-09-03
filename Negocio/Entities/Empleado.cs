using System;
using System.Collections.Generic;

namespace Negocio.Entities;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<PagosEmpleado> PagosEmpleados { get; set; } = new List<PagosEmpleado>();

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
