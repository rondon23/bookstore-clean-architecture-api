namespace BookStore.Application.DTOs;

public class UserLoginDto
{
    public string UserName { get; set; } = default!;
    public string Password { get; set; } = default!;
}