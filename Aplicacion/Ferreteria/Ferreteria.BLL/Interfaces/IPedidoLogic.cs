using Ferreteria.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ferreteria.BLL
{
    public interface IPedidoLogic
    {
        RespuestaModel<Pedido> GetById(int id);
        RespuestaModel<Pedido> Insert(Pedido modelo);
        ResultadoBaseModel Update(Pedido modelo);
        ResultadoBaseModel Delete(Pedido modelo);
        RespuestaModel<Pedido> GetList();
        RespuestaModel<PedidoDto> Obtener(int id);
        RespuestaModel<PedidoDto> ObtenerTodos();
    }
}
     