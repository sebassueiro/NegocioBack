using System;
using System.Collections.Generic;

namespace Negocio.Entities;

public partial class Venta
{
    public int IdVenta { get; set; }

    public DateTime Fecha { get; set; }

    public int? IdCliente { get; set; }

    public int? IdEmpleado { get; set; }

    public decimal Total { get; set; }

    public bool? EsFiado { get; set; }

    public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual Empleado? IdEmpleadoNavigation { get; set; }
}
