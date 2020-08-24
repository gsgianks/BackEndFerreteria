using Dapper;
using Ferreteria.Model;
using Ferreteria.Repositories;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Ferreteria.DAL
{
    class ProveedorRepository : Repository<Proveedor>, IProveedorRepository
    {
        public ProveedorRepository(string connectionString) : base(connectionString)
        {
        }
    }
}
