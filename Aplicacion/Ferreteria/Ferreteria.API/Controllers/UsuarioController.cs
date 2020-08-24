using Ferreteria.BLL;
using Ferreteria.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ferreteria.API.Controllers
{
    [ApiController]
    [Route("api/Usuario")]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioLogic _logic;

        public UsuarioController(IUsuarioLogic logic)
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
        public IActionResult Post([FromBody] Usuario usuario)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(_logic.Insert(usuario));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Usuario usuario)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(_logic.Update(usuario));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(short id)
        {
            if (id <= 0)
                return BadRequest();

            return Ok(_logic.Delete(new Usuario() { Id = id }));
        }
    }
}
