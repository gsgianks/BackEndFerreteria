using Ferreteria.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ferreteria.BLL
{
    public interface IPedidoDetalleLogic
    {
        RespuestaModel<PedidoDetalle> GetById(int id);
        RespuestaModel<PedidoDetalle> Insert(PedidoDetalle modelo);
        ResultadoBaseModel Update(PedidoDetalle modelo);
        ResultadoBaseModel Delete(PedidoDetalle modelo);
        RespuestaModel<PedidoDetalle> GetList();
        RespuestaModel<PedidoDetalleDto> Obtener(int id);
        RespuestaModel<PedidoDetalleDto> ObtenerTodos();
    }
}
     