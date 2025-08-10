
using interrapidisimoBack;
using interrapidisimoBack.Context;
using interrapidisimoBack.Models;
using InterrapidisimoBack.DTO.ProfesorDto;
using InterrapidisimoBack.DTO.UsuarioDto;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
public class EstudianteRepository : IEstudianteRepository
{
    private readonly InterrapidisimoContext _context;
    public EstudianteRepository(InterrapidisimoContext context)
    {
        _context = context;
    }
    public async Task<Estudiante> GetEstudianteByIdUsuarioAsync(int idUsuario)
    {
        var estudiante = await _context.Estudiante
            .Where(u => u.Id == idUsuario).FirstOrDefaultAsync();

        if (estudiante == null)
        {
            throw new Exception($"estudiante with ID {estudiante} not found.");
        }

        return estudiante;
    }

    public async Task<List<EstudianteDto>> GetAllEstudiantes()
    {
        // Obtener la lista de estudiantes desde la base de datos
        var estudiantes = await (from estudiante in _context.Estudiante
                                 select new EstudianteDto
                                 {
                                     Id = estudiante.Id,
                                     Nombre = estudiante.Nombre,
                                     Apellido = estudiante.Apellido,
                                     Email = estudiante.Email,
                                     Telefono = estudiante.Telefono
                                 }).ToListAsync();

        // Asignar las materias matriculadas a cada estudiante
        foreach (var estudiante in estudiantes)
        {
            estudiante.MateriaMatriculadas = await GetMateriasPorEstudiante(estudiante.Id);
        }

        if (estudiantes == null || !estudiantes.Any())
        {
            throw new Exception($"No se registran estudiantes en la base de datos.");
        }

        return estudiantes;
    }

    private async Task<List<Materium>> GetMateriasPorEstudiante(int idEstudiante)
    {
        List<Materium> materias = await (from materiaEstudiante in _context.MateriaEstudiantes
                              join materia in _context.Materia
                              on materiaEstudiante.MateriaId equals materia.Id
                              where materiaEstudiante.EstudianteId == idEstudiante && materiaEstudiante.Activo == true
                              select materia).ToListAsync();
        if (materias.Count == 0)
        {
            materias = new List<Materium>();
        }

        return materias;
    }


}