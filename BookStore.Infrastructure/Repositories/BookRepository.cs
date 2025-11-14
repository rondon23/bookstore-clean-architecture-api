using BookStore.Application.Interfaces;
using BookStore.Domain.Entities;
using BookStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Repositories;

public class BookRepository : IBookRepository
{
    private readonly BookStoreDbContext _context;

    public BookRepository(BookStoreDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Book>> GetAllAsync() => await _context.Books.Include(b => b.Author).ToListAsync();

    public async Task<Book?> GetByIdAsync(int id) => await _context.Books.Include(b => b.Author).FirstOrDefaultAsync(b => b.Id == id);

    public async Task<Book> AddAsync(Book book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
        return book;
    }

    public async Task UpdateAsync(Book book)
    {
        _context.Books.Update(book);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book != null)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
    }
}