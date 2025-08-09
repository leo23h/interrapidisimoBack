using interrapidisimoBack;

namespace InterrapidisimoBack.DTO.ProfesorDto
{
    public class ProfesorDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Email { get; set; } = null!;
        public long Telefono { get; set; }
        public List<Materium>? MateriaAsignada { get; set; }
        
    }
}