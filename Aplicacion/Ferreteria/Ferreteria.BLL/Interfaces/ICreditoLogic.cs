using Ferreteria.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ferreteria.BLL
{
    public interface ICreditoLogic
    {
        RespuestaModel<Credito> GetById(int id);
        RespuestaModel<Credito> Insert(Credito modelo);
        ResultadoBaseModel Update(Credito modelo);
        ResultadoBaseModel Delete(Credito modelo);
        RespuestaModel<Credito> GetList();
        RespuestaModel<CreditoDto> ObtenerPorUsuario(int id);
        RespuestaModel<CreditoDto> ObtenerTodos();
        RespuestaModel<CreditoDto> ObtenerCreditoUsuario();
    }
}
     