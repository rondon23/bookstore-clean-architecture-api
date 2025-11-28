using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;
using BookStore.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using BookStore.Infrastructure.Data;

namespace BookStore.Application.Services;

public class AuthService : IAuthService
{
    private readonly BookStoreDbContext _context;
    private readonly IConfiguration _config;

    public AuthService(BookStoreDbContext context, IConfiguration config)
    {
        _context = context;
        _config = config;
    }

    public async Task<string?> AuthenticateAsync(UserLoginDto dto)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(x => x.UserName == dto.UserName);

        if (user is null)
            return null;

        if (!VerifyPassword(dto.Password, user.PasswordHash))
            return null;

        return GenerateJwt(user);
    }

    private bool VerifyPassword(string password, string hash)
    {
        // Para produção, use BCrypt ou PBKDF2
        return hash == Convert.ToBase64String(Encoding.UTF8.GetBytes(password));
    }

    private string GenerateJwt(User user)
    {
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_config["Jwt:Key"]!)
        );

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Role, user.Role),
            new Claim("UserId", user.Id.ToString())
        };

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(2),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}