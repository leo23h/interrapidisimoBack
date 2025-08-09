using interrapidisimoBack.Models;
using InterrapidisimoBack.DTO.RegistroDto;
using InterrapidisimoBack.DTO.UsuarioDto;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _repository;

    public UsuarioService(IUsuarioRepository repository)
    {
        _repository = repository;
    }

    public async Task<UsuarioDto> GetUsuarioByEmailAsync(string email)
    {
        if (string.IsNullOrEmpty(email))
        {
            throw new ArgumentException("Email no puede ser un campo vacio", nameof(email));
        }

        return await _repository.GetUsuarioByIdAsync(email);
    }
    
    public async Task<Estudiante> RegisterUsuarioAsync(RegistroDto body)
     {
        if (body == null)
        {
            throw new ArgumentNullException(nameof(body), "El cuerpo de la solicitud no puede ser nulo");
        }

        return await _repository.RegisterUsuarioAsync(body);
    }
}