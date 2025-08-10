
using interrapidisimoBack;
using interrapidisimoBack.Context;
using InterrapidisimoBack.DTO.ProfesorDto;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
public class ProfesorRepository : IProfesorRepository
{
    private readonly InterrapidisimoContext _context;
    public ProfesorRepository(InterrapidisimoContext context)
    {
        _context = context;
    }
    public async Task<List<ProfesorDto>> GetAllProfesor()
    {
        var query = await (from profesor in _context.Profesors
                       select new ProfesorDto
                       {
                           Id = profesor.Id,
                           Nombre = profesor.Nombre,
                           Apellido = profesor.Apellido,
                           Email = profesor.Email,
                           Telefono = profesor.Telefono,
                           MateriaAsignada = _context.Materia
                                 .Where(m => m.ProfesorId == profesor.Id)
                                 .ToList()

                       }).ToListAsync();

        if (query == null || !query.Any())
        {
            throw new Exception($"No se registran profesores en la base de datos.");
        }

         return query;
    }
}