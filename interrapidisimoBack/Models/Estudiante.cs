namespace interrapidisimoBack.Models;

public partial class Estudiante
{
    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public long UsuarioId { get; set; }

    public int Id { get; set; }
}
