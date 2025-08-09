using interrapidisimoBack;
using InterrapidisimoBack.DTO.MateriaDto;
using InterrapidisimoBack.DTO.MateriaRequestDto;
public class MateriaService : IMateriaService
{
    private readonly IMateriaRepository _repository;

    public MateriaService(IMateriaRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Materium>> GetAllMaterias()
    {
        return await _repository.GetAllMateria();
    }

    public async Task<MateriaRequestDto> MatricularMateriasPorEstudiante(MateriaRequestDto body)
    {
        if (body == null)
        {
            throw new ArgumentNullException(nameof(body), "El cuerpo de la solicitud no puede ser nulo.");
        }
        return await _repository.MatricularMateriasPorEstudiante(body);
    }
    public Task<MateriaRequestDto> EliminarMateriasPorEstudiante(MateriaRequestDto body)
    {
        if (body == null)
        {
            throw new ArgumentNullException(nameof(body), "El cuerpo de la solicitud no puede ser nulo.");
        }
        return _repository.EliminarMateriasPorEstudiante(body);
    }

    public async Task<List<MateriaDto>> GetMateriasPorEstudianteAsync(int idEstudiante)
    {
        if (idEstudiante <= 0)
        {
            throw new ArgumentException("El ID del estudiante debe ser un número positivo.", nameof(idEstudiante));
        }
        return await _repository.GetMateriasPorEstudianteAsync(idEstudiante);
    }
}