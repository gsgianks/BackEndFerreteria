using Ferreteria.BLL;
using Ferreteria.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ferreteria.API.Controllers
{
    [ApiController]
    [Route("api/Categoria")]
    [Authorize]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaLogic _logic;

        public CategoriaController(ICategoriaLogic logic)
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
        public IActionResult Post([FromBody] Categoria Categoria)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(_logic.Insert(Categoria));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Categoria Categoria)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(_logic.Update(Categoria));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(short id)
        {
            if (id <= 0)
                return BadRequest();

            return Ok(_logic.Delete(new Categoria() { Id = id }));
        }
    }
}
