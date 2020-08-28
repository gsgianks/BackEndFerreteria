using Dapper;
using Ferreteria.Common;
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

        public IEnumerable<CreditoDto> ObtenerPorUsuario(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id_Usuario", id);

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<CreditoDto>("dbo.PA_Obtener_Credito",
                                                    parameters,
                                                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public IEnumerable<CreditoDto> ObtenerCreditoUsuario()
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Estado_Pendiente", Constantes.Codigo_Estado_Pendiente);
            parameters.Add("@Rol", Constantes.Rol_Credito);

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<CreditoDto>("dbo.PA_Obtener_Credito_Usuario",
                                                    parameters,
                                                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
