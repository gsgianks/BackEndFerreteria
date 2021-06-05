using Ferreteria.BLL;
using Ferreteria.Model;
using Ferreteria.Model.Autenticacion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ferreteria.API.Controllers
{
    [ApiController]
    [Route("api/Credito")]
    [Authorize]
    public class CreditoController : ControllerBase
    {
        private readonly ICreditoLogic _logic;

        public CreditoController(ICreditoLogic logic)
        {
            _logic = logic;
        }

        [HttpPost]
        [Route("ListaCreditos")]
        public IActionResult ObtenerListaCreditos([FromBody] Credito modelo)
        {
            return Ok(_logic.ObtenerListaCreditos(modelo));
        }

        [HttpGet]
        [Route("CreditoUsuario/{id:int}")]
        public IActionResult ObtenerCreditoUsuario(int id)
        {
            return Ok(_logic.ObtenerCreditoUsuario(id));
        }

        [HttpGet]
        [Route("CreditoUsuario")]
        public IActionResult ConsultarCreditoUsuario()
        {
            return Ok(_logic.ConsultarCreditoUsuario());
        }
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_logic.GetById(id));
        }

        [HttpGet]
        public IActionResult GetList()
        {
            return Ok(_logic.GetList());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Credito modelo)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            modelo.Usuario_Creacion = JwtProvider.ObtenerUsuario(Request.Headers["Authorization"]);
            return Ok(_logic.Insert(modelo));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Credito modelo)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            modelo.Usuario_Modificacion = JwtProvider.ObtenerUsuario(Request.Headers["Authorization"]);
            return Ok(_logic.Update(modelo));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(short id)
        {
            if (id <= 0)
                return BadRequest();

            return Ok(_logic.Delete(new Credito() { id = id }));
        }
    }
}
