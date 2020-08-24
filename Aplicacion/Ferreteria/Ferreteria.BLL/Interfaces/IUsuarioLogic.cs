using Ferreteria.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ferreteria.BLL
{
    public interface IUsuarioLogic
    {
        Usuario ValidarUsuario(string cedula, string contrasena);
        RespuestaModel<Usuario> GetById(int id);
        RespuestaModel<Usuario> Insert(Usuario modelo);
        ResultadoBaseModel Update(Usuario modelo);
        ResultadoBaseModel Delete(Usuario modelo);
        RespuestaModel<Usuario> GetList();
        RespuestaModel<UsuarioDto> Obtener(int id);
        RespuestaModel<UsuarioDto> ObtenerTodos();
    }
}
     