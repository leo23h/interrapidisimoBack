using interrapidisimoBack.Models;
using InterrapidisimoBack.DTO.ProfesorDto;
using InterrapidisimoBack.DTO.RegistroDto;

public interface IEstudianteService
{
    Task<Estudiante> GetEstudianteByIdUsuarioAsync(int idUsuario);
    public Task<List<EstudianteDto>> GetAllEstudiantesAsync();
}