using interrapidisimoBack.Models;
using InterrapidisimoBack.DTO.ProfesorDto;
using InterrapidisimoBack.DTO.UsuarioDto;

public class EstudianteService : IEstudianteService
{
    private readonly IEstudianteRepository _repository;

    public EstudianteService(IEstudianteRepository repository)
    {
        _repository = repository;
    }

    public async Task<Estudiante> GetEstudianteByIdUsuarioAsync(int idUsuario)
    {
        try
        {
            return await _repository.GetEstudianteByIdUsuarioAsync(idUsuario);
        }
        catch (Exception ex)
        {
            throw new Exception("Error al obtener el estudiante por id usuario", ex);
        }
    }
    
     public async Task<List<EstudianteDto>> GetAllEstudiantesAsync()
    {
        try
        {
            return await _repository.GetAllEstudiantes();
        }
        catch (Exception ex)
        {
            throw new Exception("Error al obtener el estudiantes", ex);
        }
    }
}