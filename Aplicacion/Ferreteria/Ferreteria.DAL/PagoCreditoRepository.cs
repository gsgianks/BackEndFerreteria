using Dapper;
using Ferreteria.Common;
using Ferreteria.Model;
using Ferreteria.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
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
                return connection.Query<PagoCreditoDto>("dbo.PA_Obtener_Pago_Credito",
                                                    parameters,
                                                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public PagoCreditoDto Obtener(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.QueryFirst<PagoCreditoDto>("dbo.PA_Obtener_Pago_Credito",
                                                    parameters,
                                                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public ResultadoBaseModel InsertarPagoCredito(PagoCredito model)
        {
            ResultadoBaseModel resultado = new ResultadoBaseModel();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Estado_Pendiente", Constantes.Codigo_Estado_Pendiente);
                parameters.Add("@Rol", Constantes.Rol_Credito);
                parameters.Add("@Id_Usuario", model.Id_Usuario);
                parameters.Add("@Abono", model.Abono);
                parameters.Add("@Usuario", model.Usuario_Creacion);
                parameters.Add("@Estado_Pagado", Constantes.Codigo_Estado_Pagado);
                parameters.Add("@Codigo_Parametro", Constantes.Parametro_Descripcion_Saldo);
                parameters.Add("@pCodigoError", dbType: DbType.Int16, direction: ParameterDirection.Output);
                parameters.Add("@pError", dbType: DbType.String,size:4000, direction: ParameterDirection.Output);

                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Execute("dbo.PA_Insertar_Pago_Credito",
                                                        parameters,
                                                        commandType: System.Data.CommandType.StoredProcedure);
                }
                resultado.Codigo = parameters.Get<Int16>("@pCodigoError");
                resultado.Descripcion = parameters.Get<String>("@pError");
            }
            catch (Exception ex) {
                resultado.Codigo = 99;
                resultado.Descripcion = Constantes.Mensaje_Error_No_Controlado + ex.Message;
            }

            return resultado;
        }

        public IEnumerable<PagoCreditoDto> ObtenerPorUsuario(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id_Usuario", id);

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<PagoCreditoDto>("dbo.PA_Obtener_Pago_Credito",
                                                    parameters,
                                                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
