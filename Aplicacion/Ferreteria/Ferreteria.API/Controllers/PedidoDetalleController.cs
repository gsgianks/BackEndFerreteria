using Ferreteria.BLL;
using Ferreteria.Model;
using Ferreteria.Model.Autenticacion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ferreteria.API.Controllers
{
    [ApiController]
    [Route("api/PedidoDetalle")]
    [Authorize]
    public class PedidoDetalleController : ControllerBase
    {
        private readonly IPedidoDetalleLogic _logic;

        public PedidoDetalleController(IPedidoDetalleLogic logic)
        {
            _logic = logic;
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
        public IActionResult Post([FromBody] PedidoDetalle PedidoDetalle)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            PedidoDetalle.Usuario_Creacion = JwtProvider.ObtenerUsuario(Request.Headers["Authorization"]);
            return Ok(_logic.Insert(PedidoDetalle));
        }

        [HttpPut]
        public IActionResult Put([FromBody] PedidoDetalle PedidoDetalle)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            PedidoDetalle.Usuario_Modificacion = JwtProvider.ObtenerUsuario(Request.Headers["Authorization"]);
            return Ok(_logic.Update(PedidoDetalle));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(short id)
        {
            if (id <= 0)
                return BadRequest();

            return Ok(_logic.Delete(new PedidoDetalle() { id = id }));
        }
    }
}
