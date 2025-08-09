
using interrapidisimoBack;
using InterrapidisimoBack.DTO.ProfesorDto;

public interface IProfesorRepository
{
    public Task<List<ProfesorDto>> GetAllProfesor();
}