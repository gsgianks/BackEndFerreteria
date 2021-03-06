﻿using Ferreteria.BLL;
using Ferreteria.Model;
using Ferreteria.Model.Autenticacion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ferreteria.API.Controllers
{
    [ApiController]
    [Route("api/PagoCredito")]
    [Authorize]
    public class PagoCreditoController : ControllerBase
    {
        private readonly IPagoCreditoLogic _logic;

        public PagoCreditoController(IPagoCreditoLogic logic)
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
        [Route("PorUsuario/{id:int}")]
        public IActionResult ObtenerPorUsuario(int id)
        {
            return Ok(_logic.ObtenerPorUsuario(id));
        }

        [HttpGet]
        public IActionResult GetList()
        {
            return Ok(_logic.GetList());
        }

        [HttpPost]
        public IActionResult Post([FromBody] PagoCredito modelo)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            modelo.Usuario_Creacion = JwtProvider.ObtenerUsuario(Request.Headers["Authorization"]);
            return Ok(_logic.Insert(modelo));
        }

        [HttpPut]
        public IActionResult Put([FromBody] PagoCredito modelo)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(_logic.Update(modelo));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest();

            return Ok(_logic.Delete(new PagoCredito() { Id = id }));
        }

        [HttpPost]
        [Route("PagoCredito")]
        public IActionResult PagoCredito([FromBody] PagoCredito modelo)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            modelo.Usuario_Creacion = JwtProvider.ObtenerUsuario(Request.Headers["Authorization"]);
            return Ok(_logic.InsertarPagoCredito(modelo));
        }
    }
}
