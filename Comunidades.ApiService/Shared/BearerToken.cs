using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Comunidades.ApiService.Shared
{
    public static class BearerToken
    {
        public static string Key => "{C43A1DB5-13AF-4B7C-8602-7DAC55BE45FA}{F35A8F93-1695-433C-8E1A-E4B6A1B10260}";
        public static SymmetricSecurityKey SymmetricKey => new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));

        public static string Generate(DateTime expireDate, params Claim[] claims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var claimsIdentity = new ClaimsIdentity(claims);
            var credentials = new SigningCredentials(SymmetricKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = claimsIdentity,
                Expires = expireDate,
                SigningCredentials = credentials
            };
            
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var writtenToken = tokenHandler.WriteToken(token);
            return writtenToken;
        }
    }
}
