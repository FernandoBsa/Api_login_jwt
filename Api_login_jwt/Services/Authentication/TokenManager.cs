using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Services.Authentication;

public sealed class TokenManager : ITokenManager
{
    private readonly IConfiguration _configuration;

    public TokenManager(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GerarToken(Usuario usuario)
    {
        var jwtSettings = _configuration.GetSection("JwtSettings");
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(jwtSettings["SecretKey"] ?? string.Empty));
        
        var claims = new List<Claim>()
        {
            new Claim(JwtRegisteredClaimNames.Sub, usuario.Nome),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };
      
        foreach (var roles in usuario.UsuarioRoles)
        {
            claims.Add(new Claim(ClaimTypes.Role, roles.Role.UserRole));
        }
        
        var tempoExpiracaoInMinutes = jwtSettings.GetValue<int>("ExpirationTimeInMinutes");

        var token = new JwtSecurityToken(
            issuer: jwtSettings.GetValue<string>("Issuer"), 
            audience: jwtSettings.GetValue<string>("Audience"),
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(tempoExpiracaoInMinutes),
            signingCredentials: new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256));
      
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}