using apifinal.Dtos;
using apifinal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace apifinal.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUsuarioServices _services;

        public UserController(IUsuarioServices services)
        {
            _services = services;
        }

        [HttpPost]
        public ActionResult CrearUser(UsuarioDTO usuarioDTO)
        {
            try
            {
                _services.AgregarUsuario(usuarioDTO);
                return Ok("Usuario creado correctamente");
            }
            catch
            {
                return BadRequest("Error al crear usuario");
            }
        }
    }
}