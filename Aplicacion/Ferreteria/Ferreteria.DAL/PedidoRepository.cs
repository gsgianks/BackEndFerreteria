using Dapper;
using Ferreteria.Model;
using Ferreteria.Repositories;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Ferreteria.DAL
{
    class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(string connectionString) : base(connectionString)
        {
        }

        public IEnumerable<PedidoDto> ObtenerTodos()
        {
            var parameters = new DynamicParameters();

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<PedidoDto>("dbo.ObtenerPedido",
                                                    parameters,
                                                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public PedidoDto Obtener(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pId", id);

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.QueryFirst<PedidoDto>("dbo.ObtenerPedido",
                                                    parameters,
                                                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
