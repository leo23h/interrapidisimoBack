using System;
using InterrapidisimoBack.DTO.ProfesorDto;
using Microsoft.AspNetCore.Mvc;

namespace interrapidisimoBack.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
    public class ProfesorController : ControllerBase
  {
    private readonly IProfesorService _profesorService;
    public ProfesorController(IProfesorService profesorService)
    {
      _profesorService = profesorService;
    }

    [HttpGet("GetAllProfesores")]
    public async Task<ActionResult<ProfesorDto>> GetAllProfesores()
    {
      var resp = await _profesorService.GetAllProfesores();
      if (resp == null || resp.Count == 0)
      {
        return NotFound("No se encontraron profesores.");
      }

      return Ok(resp);

    }
  }
}