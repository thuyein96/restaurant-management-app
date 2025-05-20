using RestaurantManagementApp.DbService.AppDbContextModels;
namespace RestaurantManagementApp.Modules.Features.Category;

public class CategoryService : ICategoryService
{
    private readonly AppDbContext _dbContext;

    public CategoryService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<Result<IEnumerable<CategoryDto>>> GetCategoriesAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<CategoryDto>> GetCategoryByIdAsync(int categoryId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<CategoryDto>> GetCategoryByCodeAsync(string categoryCode, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<CategoryDto>> CreateCategoryAsync(CreateCategoryDto categoryDto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<CategoryDto>> DeleteCategoryAsync(int categoryId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}