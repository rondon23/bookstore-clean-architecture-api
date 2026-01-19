using BookStore.Domain.Entities;

namespace BookStore.Application.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByUsernameAsync(string username);
}
