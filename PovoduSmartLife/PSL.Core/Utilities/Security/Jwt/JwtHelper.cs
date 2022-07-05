using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using PSL.Core.Utilities.Security.Encryption;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PSL.Core.Utilities.Security.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        private Microsoft.Extensions.Configuration.IConfiguration Configuration { get; }
        private TokenOptions _tokenOptions { get; }
        private DateTime _accessTokenExpiration;
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }

        public AccesToken CreateToken(JwtAuthUser user)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelpers.Create(securityKey);
            var jwtSecurityToken = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);

            return new AccesToken()
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };
        }

        public bool ValidateToken(string accessToken)
        {
            accessToken = accessToken.Replace("Bearer", string.Empty).Trim();
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);

            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(accessToken, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = _tokenOptions.Issuer,
                    ValidAudience = _tokenOptions.Audience,
                    IssuerSigningKey = securityKey
                }, out SecurityToken validatedToken);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public string GetClaim(string accessToken, string claimType)
        {
            accessToken = accessToken.Replace("Bearer", string.Empty).Trim();
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.ReadToken(accessToken) as JwtSecurityToken;

            var stringClaimValue = securityToken.Claims.First(claim => claim.Type == claimType).Value;
            return stringClaimValue;
        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, JwtAuthUser user, SigningCredentials signingCredentials)
        {
            var jwt = new JwtSecurityToken(
                    issuer: tokenOptions.Issuer,
                    audience: tokenOptions.Audience,
                    expires: _accessTokenExpiration,
                    notBefore: DateTime.Now,
                    claims: SetClaims(user),
                    signingCredentials: signingCredentials
            );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(JwtAuthUser jwtAuthUser)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(jwtAuthUser.Id.ToString());
            claims.AddEmail(jwtAuthUser.Email);
            claims.AddName($"{jwtAuthUser.FirstName} {jwtAuthUser.LastName}");

            var jsonString = JsonConvert.SerializeObject(jwtAuthUser);
            claims.AddUserData(jsonString);

            return claims;
        }
    }
}
