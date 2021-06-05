using Ferreteria.BLL;
using Ferreteria.Model;
using Ferreteria.Model.Autenticacion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ferreteria.API.Controllers
{
    [ApiController]
    [Route("api/Proveedor")]
    [Authorize]
    public class ProveedorController : ControllerBase
    {
        private readonly IProveedorLogic _logic;

        public ProveedorController(IProveedorLogic logic)
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
        public IActionResult Post([FromBody] Proveedor Proveedor)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            Proveedor.Usuario_Creacion = JwtProvider.ObtenerUsuario(Request.Headers["Authorization"]);
            return Ok(_logic.Insert(Proveedor));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Proveedor Proveedor)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            Proveedor.Usuario_Modificacion = JwtProvider.ObtenerUsuario(Request.Headers["Authorization"]);
            return Ok(_logic.Update(Proveedor));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(short id)
        {
            if (id <= 0)
                return BadRequest();

            return Ok(_logic.Delete(new Proveedor() { Id = id }));
        }
    }
}
