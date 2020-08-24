using Ferreteria.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ferreteria.BLL
{
    public interface ICategoriaLogic
    {
        RespuestaModel<Categoria> GetById(int id);
        RespuestaModel<Categoria> Insert(Categoria modelo);
        ResultadoBaseModel Update(Categoria modelo);
        ResultadoBaseModel Delete(Categoria modelo);
        RespuestaModel<Categoria> GetList();
    }
}
     