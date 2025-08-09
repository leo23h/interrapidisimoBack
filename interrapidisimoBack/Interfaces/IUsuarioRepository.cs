
using interrapidisimoBack.Models;
using InterrapidisimoBack.DTO.RegistroDto;
using InterrapidisimoBack.DTO.UsuarioDto;

public interface IUsuarioRepository
{
   Task<UsuarioDto> GetUsuarioByIdAsync(string email);
   Task<Estudiante> RegisterUsuarioAsync(RegistroDto body);
}