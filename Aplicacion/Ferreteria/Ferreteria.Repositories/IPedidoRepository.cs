using Ferreteria.Model;
using System.Collections.Generic;

namespace Ferreteria.Repositories
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        IEnumerable<PedidoDto> ObtenerTodos();
        PedidoDto Obtener(int id);
    }
}
