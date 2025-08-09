
using interrapidisimoBack;
using interrapidisimoBack.Context;
using interrapidisimoBack.Models;
using InterrapidisimoBack.DTO.RegistroDto;
using InterrapidisimoBack.DTO.UsuarioDto;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
public class UsuarioRepository : IUsuarioRepository
{
    private readonly InterrapidisimoContext _context;
    public UsuarioRepository(InterrapidisimoContext context)
    {
        _context = context;
    }
    public async Task<UsuarioDto> GetUsuarioByIdAsync(string email)
    {
        var usuario = await _context.Usuario
            .Where(u => u.Email == email)
            .Select(u => new UsuarioDto
            {
                Id = u.Id,
                Email = u.Email
            })
            .FirstOrDefaultAsync();

        if (usuario == null)
        {
            throw new InvalidOperationException($"Usuario with email {email} not found.");
        }

        return usuario;
    }

    public async Task<Estudiante> RegisterUsuarioAsync(RegistroDto body)
    {
        var usuario = new Usuario
        {
            Email = body.Email,
            Password = body.Password,
        };
        _context.Usuario.Add(usuario);
        await _context.SaveChangesAsync();

        // obtener el id
        var usuarioId = usuario.Id;

        // Crear una nueva entidad Usuario a partir del DTO
        var estudiante = new Estudiante
        {
            Email = body.Email,
            Nombre = body.Nombre,
            Apellido = body.Apellido,
            Telefono = body.Telefono.ToString(),
            UsuarioId = usuarioId,
        };
        _context.Estudiante.Add(estudiante);
        await _context.SaveChangesAsync();
        // Retornar el usuario registrado como DTO
        return new Estudiante
        {
            Email = estudiante.Email,
            Nombre = estudiante.Nombre,
            Apellido = estudiante.Apellido,
            Telefono = estudiante.Telefono.ToString(),
        };
    }

}