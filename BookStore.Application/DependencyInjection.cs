public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IBookRepository, BookRepository>(); // já existente
        services.AddScoped<BookService>();

        return services;
    }
}
