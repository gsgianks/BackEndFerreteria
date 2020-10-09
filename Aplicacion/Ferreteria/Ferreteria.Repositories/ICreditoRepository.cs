﻿using Ferreteria.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ferreteria.Repositories
{
    public interface ICreditoRepository : IRepository<Credito>
    {
        IEnumerable<CreditoDto> ObtenerTodos();
        IEnumerable<CreditoDto> ObtenerListaCreditos(Credito model);
        IEnumerable<CreditoDto> ObtenerCreditoUsuario(int id);
        IEnumerable<CreditoDto> ConsultarCreditoUsuario();
    }
}
