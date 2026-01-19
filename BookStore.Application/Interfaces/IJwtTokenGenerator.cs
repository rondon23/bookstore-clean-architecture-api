using BookStore.Domain.Entities;

namespace BookStore.Application.Interfaces;

public interface IJwtTokenGenerator
{
    string Generate(User user);
}
