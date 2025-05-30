namespace RestaurantManagementApp.Modules.Helper;

public abstract class QueryHelper<T>
    where T : class
{
    private readonly AppDbContext _dbContext;
    public QueryHelper(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<bool> IsDuplicate(
        Expression<Func<T, bool>> expression
    )
    {
        return await _dbContext.Set<T?>().AnyAsync(
            expression
        );
    }

    public async Task<T?> GetSpecific(
        Expression<Func<T, bool>> expression
    )
    {
        return await _dbContext.Set<T?>().FirstOrDefaultAsync(
            expression
        );
    }


}