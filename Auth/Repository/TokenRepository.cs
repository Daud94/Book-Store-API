using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.IdentityModel.Tokens;

namespace BookStore.Auth.Repository;

public class TokenRepository : ITokenRepository
{
    private readonly IConfiguration _configuration;

    public TokenRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string CreateJwtToken(User.User user)
    {
        var payload = new
        {
            UserId = user.Id
        };

        var claims = new List<Claim>
        {
            new Claim("UserId", user.Id.ToString()),
        };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            _configuration["Jwt:Issuer"],
            _configuration["Jwt:Audience"],
            claims,
            expires: DateTime.Now.AddMinutes(15),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}