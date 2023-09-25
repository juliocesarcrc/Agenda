using Agenda.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Agenda.Servicos
{
    public class ServicoDeToken
    {
        public static string GenerateToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(Key.Secret);
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);
            var tokenConfig = new SecurityTokenDescriptor
            {
                Subject = GenerateClaims(usuario),
                SigningCredentials = credentials,
                Expires = DateTime.UtcNow.AddHours(3)
            };

            var token = tokenHandler.CreateToken(tokenConfig);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }

        private static ClaimsIdentity GenerateClaims(Usuario usuario)
        {
            var claimIdentity = new ClaimsIdentity();
            claimIdentity.AddClaim( new Claim(ClaimTypes.Name, usuario.Nome));
            claimIdentity.AddClaim( new Claim(ClaimTypes.Role, usuario.Role));
            claimIdentity.AddClaim(new Claim("Administrador", usuario.Administrador.ToString()));

            return claimIdentity;
        }
    }
}
