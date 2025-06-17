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
    public virtual DbSet<TblCart> TblCarts { get; set; }
    public virtual DbSet<TblCartItem> TblCartItems { get; set; }
    public virtual DbSet<TblUser> TblUsers { get; set; }
    public virtual DbSet<TblCustomer> TblCustomers { get; set; }
    public virtual DbSet<TblAdmin> TblAdmins { get; set; }
    public virtual DbSet<TblBookingSlot> TblBookingSlots { get; set; }
    public virtual DbSet<TblReservation> TblReservations { get; set; }
    public virtual DbSet<TblTable> TblTables { get; set; }
    public virtual DbSet<TblOrder> TblOrders { get; set; }
    public virtual DbSet<TblOrderDetails> TblOrderDetails { get; set; }
    public virtual DbSet<TblQueue> TblQueues { get; set; }
}