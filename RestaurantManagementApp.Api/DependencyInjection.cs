namespace RestaurantManagementApp.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services,
        WebApplicationBuilder builder)
    {
        return services
            .AddDbContextService(builder)
            .AddDataAccessService();
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

    private static IServiceCollection AddDataAccessService(this IServiceCollection services)
    {
        return services
            .AddScoped<ICategoryService, CategoryService>()
            .AddScoped<IMenuItemService, MenuItemService>()
            .AddScoped<ICustomizeOptionService, CustomizeOptionService>()
            .AddScoped<ICartService, CartService>()
            .AddScoped<IBookingSlotService, BookingSlotService>()
            .AddScoped<IReservationService, ReservationService>()
            .AddScoped<ITableService, TableService>()
            .AddScoped<IOrderService, OrderService>()
            .AddScoped<IQueueService, QueueService>();
    }
}