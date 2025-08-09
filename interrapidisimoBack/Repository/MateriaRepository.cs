
using interrapidisimoBack;
using interrapidisimoBack.Context;
using interrapidisimoBack.Models;
using InterrapidisimoBack.DTO.MateriaDto;
using InterrapidisimoBack.DTO.MateriaRequestDto;
using InterrapidisimoBack.DTO.ProfesorDto;
using Microsoft.EntityFrameworkCore;
public class MateriaRepository : IMateriaRepository
{
    private readonly InterrapidisimoContext _context;
    public MateriaRepository(InterrapidisimoContext context)
    {
        _context = context;
    }
    public async Task<List<Materium>> GetAllMateria()
    {
        var query = await _context.Materia.ToListAsync();
        return query;
    }

    public async Task<MateriaRequestDto> MatricularMateriasPorEstudiante(MateriaRequestDto body)
    {
        var materiaEst = new MateriaEstudiante
        {
            EstudianteId = body.IdEstudiante,
            MateriaId = body.IdMateria,
            Activo = true
        };
        _context.MateriaEstudiantes.Add(materiaEst);
        await _context.SaveChangesAsync();

        return new MateriaRequestDto
        {
            IdEstudiante = (int)materiaEst.EstudianteId,
            IdMateria = (int)materiaEst.MateriaId,
        };
    }

    public async Task<MateriaRequestDto> EliminarMateriasPorEstudiante(MateriaRequestDto body)
    {
        var query = await _context.MateriaEstudiantes.FirstOrDefaultAsync(p => p.EstudianteId == body.IdEstudiante && p.MateriaId == body.IdMateria);
        if (query != null)
        {
            query.Activo = false;
            _context.MateriaEstudiantes.Update(query!);
        }
        else
        {
            throw new InvalidOperationException($"no se encuentra la materia con el id {body.IdMateria} matriculada por el estudiante con id {body.IdEstudiante}");
        }

        await _context.SaveChangesAsync();
        return new MateriaRequestDto
        {
            IdEstudiante = (int)query.EstudianteId,
            IdMateria = (int)query.MateriaId,
        };
    }

    public async Task<List<MateriaDto>> GetMateriasPorEstudianteAsync(int idEstudiante)
    {
        var materias = await (from materiaEstudiante in _context.MateriaEstudiantes
                              join materia in _context.Materia
                              on materiaEstudiante.MateriaId equals materia.Id
                              join profesor in _context.Profesors
                              on materia.ProfesorId equals profesor.Id
                              where materiaEstudiante.EstudianteId == idEstudiante && materiaEstudiante.Activo
                              select new MateriaDto
                              {
                                    Id = materia.Id,
                                    Nombre = materia.Nombre,
                                    Codigo = materia.Codigo,
                                    Creditos = materia.Creditos,
                                    Profesor = new Profesor
                                    {
                                        Id = profesor.Id,
                                        Nombre = profesor.Nombre,
                                        Apellido = profesor.Apellido,
                                        Email = profesor.Email
                                    }
                              }).ToListAsync();

        return materias;
    }


}