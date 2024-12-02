namespace WattHappens.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructuresServices(this IServiceCollection services, AppSettings configuration)
    {
        // services.AddDbContextFactory<ApplicationDbContext>(options =>
        //     options.UseSqlite(configuration.ConnectionStrings.DefaultConnection));

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite(configuration.ConnectionStrings.DefaultConnection));

        services.AddScoped<ApplicationDbContextInitializer>();
        
        services.AddSingleton<ProcessingStateContainer>();

        return services;
    }
}