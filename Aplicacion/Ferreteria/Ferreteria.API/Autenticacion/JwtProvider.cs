﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Ferreteria.Model.Autenticacion
{
    public class JwtProvider : ITokenProvider
    {
        private RsaSecurityKey _key;
        private string _algoritm;
        private string _issuer;
        private string _audience;

        public JwtProvider(string issuer, string audience, string keyname)
        {
            var parameters = new CspParameters()
            {
                KeyContainerName = keyname,
                Flags = CspProviderFlags.UseMachineKeyStore
            };
            var provider = new RSACryptoServiceProvider(2048, parameters);
            _key = new RsaSecurityKey(provider);
            _algoritm = SecurityAlgorithms.RsaSha256Signature;
            _issuer = issuer;
            _audience = audience;
        }

        public string CreateToken(Usuario user, DateTime expiry)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            var identity = new ClaimsIdentity(new List<Claim>()
                            {
                                new Claim(ClaimTypes.Name,$"{user.Nombre}"),
                                new Claim(ClaimTypes.NameIdentifier,user.Identificacion),
                                new Claim(ClaimTypes.PrimarySid,user.Id.ToString()),
                            }, "Custom");
            SecurityToken token = tokenHandler.CreateJwtSecurityToken(new SecurityTokenDescriptor
            {
                Audience = _audience,
                Issuer = _issuer,
                SigningCredentials = new SigningCredentials(_key, _algoritm),
                Expires = expiry.ToUniversalTime(),
                Subject = identity
            });

            return tokenHandler.WriteToken(token);
        }

        public TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters
            {
                IssuerSigningKey = _key,
                ValidAudience = _audience,
                ValidIssuer = _issuer,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.FromSeconds(0)
            };
        }

        public static string ObtenerUsuario(string jwt) {
            JwtSecurityToken token = new JwtSecurityTokenHandler().ReadJwtToken(jwt.Split(' ')[1]);
            return token.Claims.First(c => c.Type == "nameid").Value;
        }
    }
}
