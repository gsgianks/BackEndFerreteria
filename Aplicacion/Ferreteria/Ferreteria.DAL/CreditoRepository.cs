using Dapper;
using Ferreteria.Model;
using Ferreteria.Repositories;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Ferreteria.DAL
{
    class CreditoRepository : Repository<Credito>, ICreditoRepository
    {
        public CreditoRepository(string connectionString) : base(connectionString)
        {
        }

        public IEnumerable<CreditoDto> ObtenerTodos()
        {
            var parameters = new DynamicParameters();

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<CreditoDto>("dbo.ObtenerCredito",
                                                    parameters,
                                                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public CreditoDto Obtener(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pId", id);

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.QueryFirst<CreditoDto>("dbo.ObtenerCredito",
                                                    parameters,
                                                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
