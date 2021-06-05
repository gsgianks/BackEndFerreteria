using Ferreteria.BLL;
using Ferreteria.Model;
using Ferreteria.Model.Autenticacion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ferreteria.API.Controllers
{
    [ApiController]
    [Route("api/Pedido")]
    [Authorize]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoLogic _logic;

        public PedidoController(IPedidoLogic logic)
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
        public IActionResult Post([FromBody] Pedido Pedido)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            Pedido.Usuario_Creacion = JwtProvider.ObtenerUsuario(Request.Headers["Authorization"]);
            return Ok(_logic.Insert(Pedido));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Pedido Pedido)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(_logic.Update(Pedido));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(short id)
        {
            if (id <= 0)
                return BadRequest();

            return Ok(_logic.Delete(new Pedido() { Id = id }));
        }
    }
}
