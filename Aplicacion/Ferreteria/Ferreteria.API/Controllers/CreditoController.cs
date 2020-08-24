using Ferreteria.BLL;
using Ferreteria.Model;
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
        public IActionResult Post([FromBody] Credito Credito)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(_logic.Insert(Credito));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Credito Credito)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(_logic.Update(Credito));
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
