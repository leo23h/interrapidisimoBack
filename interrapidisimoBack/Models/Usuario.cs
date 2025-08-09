using System;
using System.Collections.Generic;

namespace interrapidisimoBack;

public partial class Usuario
{
    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int Id { get; set; }
}
