using BookStore.Application.Interfaces;
using BookStore.Domain.Entities;
using BookStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly BookStoreDbContext _context;

    public UserRepository(BookStoreDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        return await _context.Users
            .FirstOrDefaultAsync(x => x.UserName == username);
    }
}
