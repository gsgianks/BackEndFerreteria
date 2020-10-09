using Ferreteria.Model;
using System.Collections.Generic;

namespace Ferreteria.Repositories
{
    public interface IPagoCreditoRepository : IRepository<PagoCredito>
    {
        IEnumerable<PagoCreditoDto> ObtenerTodos();
        PagoCreditoDto Obtener(int id);
        ResultadoBaseModel InsertarPagoCredito(PagoCredito model);
        IEnumerable<PagoCreditoDto> ObtenerPorUsuario(int id);
    }
}
