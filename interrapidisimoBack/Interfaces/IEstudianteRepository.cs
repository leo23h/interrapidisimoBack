
using interrapidisimoBack.Models;
using InterrapidisimoBack.DTO.ProfesorDto;

public interface IEstudianteRepository
{
    public Task<Estudiante> GetEstudianteByIdUsuarioAsync(int idUsuario);
    public Task<List<EstudianteDto>> GetAllEstudiantes();
}