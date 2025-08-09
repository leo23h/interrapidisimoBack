
namespace interrapidisimoBack.Models;

public partial class MateriaEstudiante
{
    public int Id { get; set; }

    public long MateriaId { get; set; }

    public long EstudianteId { get; set; }

    public bool Activo { get; set; }
}
