using Ferreteria.BLL;
using Ferreteria.Model;
using Ferreteria.Model.Autenticacion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ferreteria.API.Controllers
{
    [ApiController]
    [Route("api/Producto")]
    [Authorize]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoLogic _logic;

        public ProductoController(IProductoLogic logic)
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
        public IActionResult Post([FromBody] Producto Producto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            Producto.Usuario_Creacion = JwtProvider.ObtenerUsuario(Request.Headers["Authorization"]);
            return Ok(_logic.Insert(Producto));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Producto Producto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            Producto.Usuario_Modificacion = JwtProvider.ObtenerUsuario(Request.Headers["Authorization"]);
            return Ok(_logic.Update(Producto));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(short id)
        {
            if (id <= 0)
                return BadRequest();

            return Ok(_logic.Delete(new Producto() { Id = id }));
        }
    }
}
