using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RestaurantManagementApp.DbService.AppDbContextModels;

namespace RestaurantManagementApp.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services,
        WebApplicationBuilder builder)
    {
        return services.AddDbContextService(builder);
    }

    private static IServiceCollection AddDbContextService(this IServiceCollection services,
       WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseMySql(
                builder.Configuration.GetConnectionString("DefaultConnection"),
                ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection")),
                x => x.MigrationsAssembly("RestaurantManagementApp.DbService")));
        return services;
    }
}