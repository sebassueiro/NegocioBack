using System;
using System.Collections.Generic;

namespace Negocio.Entities;

public partial class PagosCliente
{
    public int IdPago { get; set; }
    public int IdCliente { get; set; }
    public DateTime Fecha { get; set; }
    public int Pagado { get; set; }
    public int Deuda { get; set; }
    public int Saldo { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;
}
