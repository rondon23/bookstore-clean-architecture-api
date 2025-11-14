using Microsoft.EntityFrameworkCore;
using BookStore.Domain.Entities;

namespace BookStore.Infrastructure.Data;

public class BookStoreDbContext : DbContext
{
    public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options) {}

    public DbSet<Book> Books => Set<Book>();
    public DbSet<Author> Authors => Set<Author>();
    public DbSet<User> Users => Set<User>();
}