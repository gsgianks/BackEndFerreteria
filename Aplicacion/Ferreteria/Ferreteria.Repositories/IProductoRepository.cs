using Ferreteria.Model;
using System.Collections.Generic;

namespace Ferreteria.Repositories
{
    public interface IProductoRepository : IRepository<Producto>
    {
        IEnumerable<ProductoDto> ObtenerTodos();
        ProductoDto Obtener(int id);
    }
}
