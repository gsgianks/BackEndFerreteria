using Dapper;
using Ferreteria.Model;
using Ferreteria.Repositories;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Ferreteria.DAL
{
    class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(string connectionString) : base(connectionString)
        {
        }

        public IEnumerable<UsuarioDto> ObtenerTodos()
        {
            var parameters = new DynamicParameters();

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<UsuarioDto>("dbo.PA_Obtener_Usuario",
                                                    parameters,
                                                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public UsuarioDto Obtener(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pId", id);

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.QueryFirst<UsuarioDto>("dbo.PA_Obtener_Usuario",
                                                    parameters,
                                                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public Usuario ValidarUsuario(string correo, string contrasena)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pIdentificacion", correo);
            parameters.Add("@pContasena", contrasena);

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.QueryFirstOrDefault<Usuario>(
                    "dbo.PA_Validar_Usuario", parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }
    }
}
