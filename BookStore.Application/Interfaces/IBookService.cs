using BookStore.Domain.Entities;

namespace BookStore.Application.Interfaces;

public interface IBookService
{
    Task<IEnumerable<Book>> GetAllBooksAsync();
    Task<Book?> GetBookByIdAsync(int id);
    Task<Book> CreateBookAsync(Book book);
    Task UpdateBookAsync(Book book);
    Task DeleteBookAsync(int id);
}