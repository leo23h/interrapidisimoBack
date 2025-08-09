
using interrapidisimoBack;
using InterrapidisimoBack.DTO.MateriaDto;
using InterrapidisimoBack.DTO.MateriaRequestDto;
using InterrapidisimoBack.DTO.ProfesorDto;

public interface IMateriaRepository
{
    public Task<List<Materium>> GetAllMateria();
    public Task<MateriaRequestDto> MatricularMateriasPorEstudiante(MateriaRequestDto body);
    public Task<MateriaRequestDto> EliminarMateriasPorEstudiante(MateriaRequestDto body);
    public Task<List<MateriaDto>> GetMateriasPorEstudianteAsync(int idEstudiante);
}