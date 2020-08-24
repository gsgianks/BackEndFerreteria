using Ferreteria.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ferreteria.BLL
{
    public interface IProductoLogic
    {
        RespuestaModel<Producto> GetById(int id);
        RespuestaModel<Producto> Insert(Producto modelo);
        ResultadoBaseModel Update(Producto modelo);
        ResultadoBaseModel Delete(Producto modelo);
        RespuestaModel<Producto> GetList();
        RespuestaModel<ProductoDto> Obtener(int id);
        RespuestaModel<ProductoDto> ObtenerTodos();
    }
}
     