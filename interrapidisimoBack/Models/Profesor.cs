using System;
using System.Collections.Generic;

namespace interrapidisimoBack;

public partial class Profesor
{
    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Email { get; set; } = null!;

    public long Telefono { get; set; }

    public int Id { get; set; }
}
