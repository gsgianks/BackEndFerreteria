using Dapper;
using Ferreteria.Model;
using Ferreteria.Repositories;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Ferreteria.DAL
{
    class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(string connectionString) : base(connectionString)
        {
        }

       
    }
}
