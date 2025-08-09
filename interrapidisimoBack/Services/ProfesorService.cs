using InterrapidisimoBack.DTO.ProfesorDto;

public class ProfesorService: IProfesorService
{
    private readonly IProfesorRepository _repository;

    public ProfesorService(IProfesorRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ProfesorDto>> GetAllProfesores()
    {
        return await _repository.GetAllProfesor();
    }
}