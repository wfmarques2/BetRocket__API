using Domain.Interfaces.Services;
using Infra.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Services;

public class TokenService : ITokenService<EntityUser>
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(EntityUser user)
    {
        Claim[] claims = new Claim[]
        {
            new Claim("username", user.UserName!),
            new Claim("id", user.Id),
            new Claim(ClaimTypes.DateOfBirth,
            user.BirthDate.ToString()),
            new Claim("isAdmin", user.IsAdmin.ToString())
        };

        var key = new SymmetricSecurityKey
            (Encoding.UTF8.GetBytes
            (_configuration["SymmetricSecurityKey"]!));

        var signinCredential = new SigningCredentials(key,
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken
        (
            expires: DateTime.Now.AddHours(8),
            claims: claims,
            signingCredentials: signinCredential
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
