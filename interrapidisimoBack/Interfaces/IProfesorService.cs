using InterrapidisimoBack.DTO.ProfesorDto;
using InterrapidisimoBack.DTO.UsuarioDto;

public interface IProfesorService
{
    public Task<List<ProfesorDto>> GetAllProfesores();
}