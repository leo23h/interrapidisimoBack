using interrapidisimoBack;
using InterrapidisimoBack.DTO.MateriaDto;
using InterrapidisimoBack.DTO.MateriaRequestDto;

public interface IMateriaService
{
    public Task<List<Materium>> GetAllMaterias();
    public Task<MateriaRequestDto> MatricularMateriasPorEstudiante(MateriaRequestDto body);
    public Task<MateriaRequestDto> EliminarMateriasPorEstudiante(MateriaRequestDto body);
    public Task<List<MateriaDto>> GetMateriasPorEstudianteAsync(int idEstudiante);
}