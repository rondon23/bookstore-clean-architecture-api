using BookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace BookStore.Infrastructure.Data;

public static class SeedData
{
    public static void SeedUsers(ModelBuilder builder)
    {
        var admin = new User
        {
            Id = 1,
            UserName = "admin",
            PasswordHash = Convert.ToBase64String(Encoding.UTF8.GetBytes("123456")),
            Role = "Admin"
        };

        builder.Entity<User>().HasData(admin);
    }
}