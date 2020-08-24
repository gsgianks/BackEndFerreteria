using Ferreteria.Model;
using System.Collections.Generic;

namespace Ferreteria.Repositories
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        IEnumerable<UsuarioDto> ObtenerTodos();
        UsuarioDto Obtener(int id);
        Usuario ValidarUsuario(string correo, string contrasena);
    }
}
