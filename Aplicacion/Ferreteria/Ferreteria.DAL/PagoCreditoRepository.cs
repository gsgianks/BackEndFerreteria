using Dapper;
using Ferreteria.Model;
using Ferreteria.Repositories;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Ferreteria.DAL
{
    class PagoCreditoRepository : Repository<PagoCredito>, IPagoCreditoRepository
    {
        public PagoCreditoRepository(string connectionString) : base(connectionString)
        {
        }

        public IEnumerable<PagoCreditoDto> ObtenerTodos()
        {
            var parameters = new DynamicParameters();

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<PagoCreditoDto>("dbo.ObtenerPagoCredito",
                                                    parameters,
                                                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public PagoCreditoDto Obtener(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pId", id);

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.QueryFirst<PagoCreditoDto>("dbo.ObtenerPagoCredito",
                                                    parameters,
                                                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
