using Ferreteria.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ferreteria.Repositories
{
    public interface ICreditoRepository : IRepository<Credito>
    {
        IEnumerable<CreditoDto> ObtenerTodos();
        IEnumerable<CreditoDto> ObtenerPorUsuario(int id);
        IEnumerable<CreditoDto> ObtenerCreditoUsuario();
    }
}
