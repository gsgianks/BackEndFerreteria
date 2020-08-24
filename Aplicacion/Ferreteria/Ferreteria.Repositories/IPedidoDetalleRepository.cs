using Ferreteria.Model;
using System.Collections.Generic;

namespace Ferreteria.Repositories
{
    public interface IPedidoDetalleRepository : IRepository<PedidoDetalle>
    {
        IEnumerable<PedidoDetalleDto> ObtenerTodos();
        PedidoDetalleDto Obtener(int id);
    }
}
