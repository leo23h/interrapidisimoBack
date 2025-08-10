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
            try
            {
                if (!string.IsNullOrEmpty(request.Email))
                {
                    var resp = await _usuarioService.GetUsuarioByEmailAsync(request.Email);
                    if (resp == null)
                    {
                        return NotFound();
                    }
                    return StatusCode(200, new { resp });
                }
                else
                {
                    return StatusCode(400, new { mensaje = "El email no puede ser un campo vacio" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Error interno del servidor", error = ex.Message });
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
                    return StatusCode(400, new { mensaje = "error al registrar usuario" });
                }
                return StatusCode(200, new { resp });
            }
            else
            {
                return StatusCode(400, new { mensaje = "body no puede estar vacio" });
            }
        }
    }
}
