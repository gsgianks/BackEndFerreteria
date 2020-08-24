using Microsoft.IdentityModel.Tokens;
using System;

namespace Ferreteria.Model.Autenticacion
{
    public interface ITokenProvider
    {
        string CreateToken(Usuario usuario, DateTime expira);
        TokenValidationParameters GetValidationParameters();
    }
}
