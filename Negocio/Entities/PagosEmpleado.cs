using System;
using System.Collections.Generic;

namespace Negocio.Entities;

public partial class PagosEmpleado
{
    public int IdPagoEmpleado { get; set; }

    public int IdEmpleado { get; set; }

    public DateTime Fecha { get; set; }

    public decimal Monto { get; set; }

    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;
}
