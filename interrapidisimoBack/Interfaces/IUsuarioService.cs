using interrapidisimoBack.Models;
using InterrapidisimoBack.DTO.RegistroDto;
using InterrapidisimoBack.DTO.UsuarioDto;

public interface IUsuarioService
{
    Task<UsuarioDto> GetUsuarioByEmailAsync(string email);
    Task<Estudiante> RegisterUsuarioAsync(RegistroDto body);
}