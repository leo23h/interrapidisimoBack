using interrapidisimoBack;

namespace InterrapidisimoBack.DTO.MateriaDto
{
    public class MateriaDto
    {
        public string Nombre { get; set; } = null!;

        public string Codigo { get; set; } = null!;

        public long Creditos { get; set; }

        public Profesor? Profesor{ get; set; }

        public int Id { get; set; }

    }
}