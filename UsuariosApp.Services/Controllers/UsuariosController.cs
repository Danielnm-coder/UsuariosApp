using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsuariosApp.Domain.Interfaces;
using UsuariosApp.Services.Models;

namespace UsuariosApp.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioDomainService? _usuarioDomainService;

        public UsuariosController(IUsuarioDomainService? usuarioDomainService)
        {
            _usuarioDomainService = usuarioDomainService;
        }

        /// <summary>
        /// HTTP POST api/Usuarios/Autenticar
        /// </summary>
        [HttpPost("Autenticar")]
        [ProducesResponseType(typeof(AutenticarResponseModel), 200)]
        public IActionResult Autenticar([FromBody] AutenticarRequestModel model)
        {
            try
            {
                var usuario = _usuarioDomainService?.Autenticar(model.Email, model.Senha);
                var response = new AutenticarResponseModel
                {
                    Id = usuario.Id,
                    Nome = usuario.Nome,
                    Email = usuario.Email,
                    DataHoraAcesso = DateTime.Now
                };

                //HTTP 200 (OK)
                return StatusCode(200, response);
            }
            catch (ApplicationException e)
            {
                //HTTP 401 (UNAUTHORIZED)
                return StatusCode(401, new { e.Message });
            }
            catch (Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { e.Message });
            }
        }
    }
}



