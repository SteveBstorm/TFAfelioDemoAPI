using BLL.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DemoAPI.Infrastructure
{
    public class TokenManager
    {
        private readonly string _secret, _issuer, _audience;

        public TokenManager(IConfiguration config)
        {
            _secret = config.GetSection("TokenInfo").GetSection("secret").Value;
            _issuer = config.GetSection("TokenInfo").GetSection("issuer").Value;
            _audience = config.GetSection("TokenInfo").GetSection("audience").Value;
        }

        public string GenerateToken(User user)
        {
            if (user is null) throw new ArgumentNullException();

            //Création de la signature du token
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);


            //Création du payload / Claims
            Claim[] myclaims = new Claim[]
            {
                new Claim(ClaimTypes.Role, user.IsAdmin ? "Admin" : "User"),
                new Claim("UserId", user.Id.ToString())
            };

            //config du token
            JwtSecurityToken token = new JwtSecurityToken(
                claims: myclaims,
                signingCredentials: credentials,
                issuer: _issuer,
                audience: _audience,
                expires: DateTime.Now.AddDays(1)
                );
            //Génération du token
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(token);

        }

    }
}
