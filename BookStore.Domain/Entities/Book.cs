using BookStore.Domain.Common;

namespace BookStore.Domain.Entities;

public class Book : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int AuthorId { get; set; }
    public Author? Author { get; set; }
    public decimal Price { get; set; }
    public string Genre { get; set; } = string.Empty;
}