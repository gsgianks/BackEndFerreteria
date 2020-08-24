using Ferreteria.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ferreteria.BLL
{
    public interface IProveedorLogic
    {
        RespuestaModel<Proveedor> GetById(int id);
        RespuestaModel<Proveedor> Insert(Proveedor modelo);
        ResultadoBaseModel Update(Proveedor modelo);
        ResultadoBaseModel Delete(Proveedor modelo);
        RespuestaModel<Proveedor> GetList();
    }
}
     