using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;
using BCrypt.Net;

namespace BookStore.Application.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwt;

    public AuthService(
        IUserRepository userRepository,
        IJwtTokenGenerator jwt)
    {
        _userRepository = userRepository;
        _jwt = jwt;
    }

    public async Task<string?> AuthenticateAsync(UserLoginDto dto)
    {
        var user = await _userRepository.GetByUsernameAsync(dto.UserName);

        if (user is null)
            return null;

        if (!VerifyPassword(dto.Password, user.PasswordHash))
            return null;

        return _jwt.Generate(user);
    }

    private bool VerifyPassword(string password, string passwordHash)
    {
        return BCrypt.Net.BCrypt.Verify(password, passwordHash);
    }
}
