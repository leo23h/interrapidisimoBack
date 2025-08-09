using System;
using InterrapidisimoBack.DTO.MateriaDto;
using InterrapidisimoBack.DTO.MateriaRequestDto;
using Microsoft.AspNetCore.Mvc;

namespace interrapidisimoBack.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class MateriaController : ControllerBase
  {
    private readonly IMateriaService _materiarService;

    public MateriaController(IMateriaService materiaService)
    {
      _materiarService = materiaService;
    }

    [HttpGet("GetAllMaterias")]
    public async Task<ActionResult<Materium>> GetAllMaterias()
    {
      var resp = await _materiarService.GetAllMaterias();
      if (resp == null || resp.Count == 0)
      {
        return NotFound("No se encontraron Materias.");
      }

      return Ok(resp);

    }

    [HttpPost("MatricularMateriasPorEstudiante")]
    public async Task<ActionResult<MateriaRequestDto>> MatricularMateriasPorEstudiante(MateriaRequestDto body)
    {
      if (body == null)
      {
        return BadRequest("no hay parametros de entrada en el body");
      }
      else
      {
        var resp = await _materiarService.MatricularMateriasPorEstudiante(body);
        return Ok(resp);
      }
    }



    [HttpPost("EliminarMateriasPorEstudiante")]
    public async Task<ActionResult<MateriaRequestDto>> EliminarMateriasPorEstudiante(MateriaRequestDto body)
    {
      if (body == null)
      {
        return BadRequest("no hay parametros de entrada en el body");
      }
      else
      {
        var resp = await _materiarService.EliminarMateriasPorEstudiante(body);
        return Ok(resp);
      }
    }

    [HttpGet("GetMateriaPorIdEstudiante/{idEstudiante}")]
    public async Task<ActionResult<List<MateriaDto>>> GetUsuarioByEmail(int idEstudiante)
    {

      if (idEstudiante > 0)
      {
        var resp = await _materiarService.GetMateriasPorEstudianteAsync(idEstudiante);
        if (resp == null)
        {
          return NotFound();
        }
        return Ok(resp);
      }
      else
      {
        return BadRequest("El estudiante no puede ser un campo en 0 o vacio");
      }
    }
  }
}