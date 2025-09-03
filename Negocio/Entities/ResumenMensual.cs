using System;
using System.Collections.Generic;

namespace Negocio.Entities;

public partial class ResumenMensual
{
    public int IdResumenMensual { get; set; }

    public int Anio { get; set; }

    public int Mes { get; set; }

    public decimal Ingresos { get; set; }

    public decimal Egresos { get; set; }

    public decimal GananciaNeta { get; set; }
}
