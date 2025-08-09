using System;
using System.Collections.Generic;

namespace interrapidisimoBack;

public partial class Materium
{
    public string Nombre { get; set; } = null!;

    public string Codigo { get; set; } = null!;

    public long Creditos { get; set; }

    public long ProfesorId { get; set; }

    public int Id { get; set; }
}
