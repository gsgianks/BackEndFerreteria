using Ferreteria.BLL;
using Ferreteria.Model;
using Ferreteria.Model.Autenticacion;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Ferreteria.API.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private ITokenProvider _tokenProvider;
        private IUsuarioLogic _logic;

        public TokenController(ITokenProvider tokenProvider, IUsuarioLogic logic)
        {
            _tokenProvider = tokenProvider;
            _logic = logic;
        }
        
        [HttpPost]
        public JsonWebToken Post([FromBody] Usuario user)
        {

            ResultadoModel<Usuario, JsonWebToken> model = new ResultadoModel<Usuario, JsonWebToken>();

            user = _logic.ValidarUsuario(user.Identificacion, user.Contrasena);

            if (user == null)
            {
                throw new UnauthorizedAccessException();
            }
            var token = new JsonWebToken
            {
                Access_Token = _tokenProvider.CreateToken(user, DateTime.UtcNow.AddHours(8)),
                Expires_in = 480//minutes
            };

            return token;
        }
    }
}
