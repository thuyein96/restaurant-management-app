namespace RestaurantManagementApp.Modules.Helper;

public class QueryHelper
{
    private readonly AppDbContext _dbContext;
    public QueryHelper(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    private async Task<bool> IsDuplicate(
        Expression<Func<object, bool>> expression
    )
    {
        return await _dbContext.Set<object?>().AnyAsync(
            expression
        );
    }

    private async Task<object?> GetSpecific(
        Expression<Func<object, bool>> expression
    )
    {
        return await _dbContext.Set<object?>().FirstOrDefaultAsync(
            expression
        );
    }
}