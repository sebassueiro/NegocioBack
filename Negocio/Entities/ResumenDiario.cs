using System;
using System.Collections.Generic;

namespace Negocio.Entities;

public partial class ResumenDiario
{
    public int IdResumen { get; set; }

    public DateOnly Fecha { get; set; }

    public decimal Ingresos { get; set; }

    public decimal Egresos { get; set; }

    public decimal GananciaNeta { get; set; }
}
