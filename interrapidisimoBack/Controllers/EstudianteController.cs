using System;
using interrapidisimoBack.Models;
using InterrapidisimoBack.DTO.ProfesorDto;
using Microsoft.AspNetCore.Mvc;

namespace interrapidisimoBack.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class EstudianteController : ControllerBase
  {
    private readonly IEstudianteService _estudianteService;
    public EstudianteController(IEstudianteService estudianteService)
    {
      _estudianteService = estudianteService;
    }

    [HttpGet("GetEstudianteByIdUsuario/{idUsuario}")]
    public async Task<ActionResult<Estudiante>> GetUsuarioByEmail(int idUsuario)
    {

      if (idUsuario > 0)
      {
        var resp = await _estudianteService.GetEstudianteByIdUsuarioAsync(idUsuario);
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

    [HttpGet("GetAllEstudiantes")]
    public async Task<ActionResult<EstudianteDto>> GetAllEstudiantes()
    {
        var resp = await _estudianteService.GetAllEstudiantesAsync();
        if (resp == null)
        {
          return NotFound();
        }
        return Ok(resp);
      
    }
  }
}