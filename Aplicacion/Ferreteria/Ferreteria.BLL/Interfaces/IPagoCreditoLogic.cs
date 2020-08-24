using Ferreteria.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ferreteria.BLL
{
    public interface IPagoCreditoLogic
    {
        RespuestaModel<PagoCredito> GetById(int id);
        RespuestaModel<PagoCredito> Insert(PagoCredito modelo);
        ResultadoBaseModel Update(PagoCredito modelo);
        ResultadoBaseModel Delete(PagoCredito modelo);
        RespuestaModel<PagoCredito> GetList();
        RespuestaModel<PagoCreditoDto> Obtener(int id);
        RespuestaModel<PagoCreditoDto> ObtenerTodos();
    }
}
     