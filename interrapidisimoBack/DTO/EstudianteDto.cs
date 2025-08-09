using interrapidisimoBack;

namespace InterrapidisimoBack.DTO.ProfesorDto
{
    public class EstudianteDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public List<Materium>? MateriaMatriculadas { get; set; }
        
    }
}