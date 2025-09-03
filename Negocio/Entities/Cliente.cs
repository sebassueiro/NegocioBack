using System;
using System.Collections.Generic;

namespace Negocio.Entities;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Telefono { get; set; }

    public virtual ICollection<PagosCliente> PagosClientes { get; set; } = new List<PagosCliente>();

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
