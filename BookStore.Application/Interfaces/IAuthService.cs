using BookStore.Application.DTOs;

namespace BookStore.Application.Interfaces;

public interface IAuthService
{
    Task<string?> AuthenticateAsync(UserLoginDto dto);
}