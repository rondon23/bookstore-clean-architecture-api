using BookStore.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using BookStore.Application.Interfaces;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IBookService, BookService>();

        return services;
    }
}
