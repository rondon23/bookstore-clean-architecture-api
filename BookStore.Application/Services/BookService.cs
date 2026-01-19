using BookStore.Application.Interfaces;
using BookStore.Domain.Entities;

namespace BookStore.Application.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _repository;

    public BookService(IBookRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Book>> GetAllBooksAsync() => await _repository.GetAllAsync();

    public async Task<Book?> GetBookByIdAsync(int id) => await _repository.GetByIdAsync(id);

    public async Task<Book> CreateBookAsync(Book book) => await _repository.AddAsync(book);

    public async Task UpdateBookAsync(Book book) => await _repository.UpdateAsync(book);

    public async Task DeleteBookAsync(int id) => await _repository.DeleteAsync(id);
}