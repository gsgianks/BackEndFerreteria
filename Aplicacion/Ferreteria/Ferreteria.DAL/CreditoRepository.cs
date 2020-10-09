using Dapper;
using Ferreteria.Common;
using Ferreteria.Model;
using Ferreteria.Repositories;
using System;
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

        public IEnumerable<CreditoDto> ObtenerListaCreditos(Credito model)
        {
            #region Validación de parametros
           
            Int64? id = model.id;
            Int16? idUsuario = model.Id_Usuario;
            Int32? idPago = model.Id_Pago;
            if (model.id == 0) {
                id = null;
            }
            if (model.Id_Usuario == 0)
            {
                idUsuario = null;
            }
            if (model.Id_Pago == 0)
            {
                idPago = null;
            }

            #endregion

            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            parameters.Add("@Id_Pago", idPago);
            parameters.Add("@Id_Usuario", idUsuario);
            parameters.Add("@Estado", model.Estado);

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<CreditoDto>("dbo.PA_Obtener_Credito",
                                                    parameters,
                                                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public IEnumerable<CreditoDto> ObtenerCreditoUsuario(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Estado_Pendiente", Constantes.Codigo_Estado_Pendiente);
            parameters.Add("@Rol", Constantes.Rol_Credito);
            parameters.Add("@Id_Usuario", id);

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<CreditoDto>("dbo.PA_Obtener_Credito_Usuario",
                                                    parameters,
                                                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public IEnumerable<CreditoDto> ConsultarCreditoUsuario()
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
