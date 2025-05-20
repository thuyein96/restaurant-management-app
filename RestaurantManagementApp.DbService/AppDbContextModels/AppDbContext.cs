namespace RestaurantManagementApp.DbService.AppDbContextModels;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    public virtual DbSet<TblCategory> TblCategories { get; set; }

    public virtual DbSet<TblMenuItem> TblMenuItems { get; set; }

    public virtual DbSet<TblCustomizeOption> TblCustomizeOptions { get; set; }

    public virtual DbSet<TblMenuItemCustomizeOption> TblMenuItemCustomizeOptions { get; set; }
}