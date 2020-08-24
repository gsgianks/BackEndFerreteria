using Dapper;
using Ferreteria.Model;
using Ferreteria.Repositories;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Ferreteria.DAL
{
    class PedidoDetalleRepository : Repository<PedidoDetalle>, IPedidoDetalleRepository
    {
        public PedidoDetalleRepository(string connectionString) : base(connectionString)
        {
        }

        public IEnumerable<PedidoDetalleDto> ObtenerTodos()
        {
            var parameters = new DynamicParameters();

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<PedidoDetalleDto>("dbo.ObtenerPedidoDetalle",
                                                    parameters,
                                                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public PedidoDetalleDto Obtener(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pId", id);

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.QueryFirst<PedidoDetalleDto>("dbo.ObtenerPedidoDetalle",
                                                    parameters,
                                                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
