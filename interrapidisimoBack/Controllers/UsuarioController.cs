using System;
using interrapidisimoBack.Models;
using InterrapidisimoBack.DTO.RegistroDto;
using InterrapidisimoBack.DTO.UsuarioDto;
using Microsoft.AspNetCore.Mvc;

namespace interrapidisimoBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("GetUsuarioByEmail")]
        public async Task<ActionResult<UsuarioDto>> GetUsuarioByEmail([FromBody] UsuarioRequestDto request)
        {
            if (!string.IsNullOrEmpty(request.Email))
            {
                var resp = await _usuarioService.GetUsuarioByEmailAsync(request.Email);
                if (resp == null)
                {
                    return NotFound();
                }
                return Ok(resp);
            }
            else
            {
                return BadRequest("El email no puede ser un campo vacio");
            }
        }

        [HttpPost("RegistrarUsuario")]
        public async Task<ActionResult<Estudiante>> RegistrarUsuario([FromBody] RegistroDto request)
        {
            if (!string.IsNullOrEmpty(request.Email))
            {
                var resp = await _usuarioService.RegisterUsuarioAsync(request);
                if (resp == null)
                {
                    return NotFound();
                }
                return Ok(resp);
            }
            else
            {
                return BadRequest("El email no puede ser un campo vacio");
            }
        }
	}
}
