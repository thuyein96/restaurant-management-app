namespace RestaurantManagementApp.Modules.Features.Category;

public class CategoryService : ICategoryService
{
    private readonly AppDbContext _dbContext;

    public CategoryService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<Result<IEnumerable<CategoryDto>>> GetCategoriesAsync()
    {
        Result<IEnumerable<CategoryDto>> result;
        try
        {
            var lst = await _dbContext
                .TblCategories
                .ToListAsync();
            result = Result<IEnumerable<CategoryDto>>.Success(lst.Select(x => x.ToDto()));
        }
        catch (Exception ex)
        {
            result = Result<IEnumerable<CategoryDto>>.Failure(ex);
        }

        return result;
    }

    public async Task<Result<CategoryDto>> GetCategoryByIdAsync(Guid categoryId)
    {
        Result<CategoryDto> result;
        try
        {
            var category = await GetSpecificCategory(
                x => x.CategoryId == categoryId
            );
            if (category is null)
            {
                result = Result<CategoryDto>.NotFound("Category Not Found.");
                return result;
            }

            result = Result<CategoryDto>.Success(category.ToDto());
        }
        catch (Exception ex)
        {
            result = Result<CategoryDto>.Failure(ex);
        }

        return result;
    }

    public async Task<Result<CategoryDto>> CreateCategoryAsync(
        CreateCategoryDto categoryDto
        )
    {
        Result<CategoryDto> result;
        try
        {
            bool isDuplicate = await IsCategoryDuplicate(
                x => x.CategoryName == categoryDto.CategoryName
            );
            if (isDuplicate)
            {
                result = Result<CategoryDto>.Duplicate("Category Name already exists.");
                return result;
            }

            var newCategory = await _dbContext.TblCategories.AddAsync(categoryDto.ToEntity());
            await _dbContext.SaveChangesAsync();

            result = Result<CategoryDto>.SaveSuccess(newCategory.Entity.ToDto());
        }
        catch (Exception ex)
        {
            result = Result<CategoryDto>.Failure(ex);
        }
        
        return result;
    }

    public async Task<Result<CategoryDto>> DeleteCategoryAsync(
        Guid categoryId
        )
    {
        Result<CategoryDto> result;
        try
        {
            var category = await GetSpecificCategory(
                x => x.CategoryId == categoryId
            );
            if (category is null)
            {
                result = Result<CategoryDto>.NotFound("Category Not Found.");
                return result;
            }

            var removedCategory = _dbContext.TblCategories.Remove(category);
            await _dbContext.SaveChangesAsync();

            result = Result<CategoryDto>.DeleteSuccess(removedCategory.Entity.ToDto());
        }
        catch (Exception ex)
        {
            result = Result<CategoryDto>.Failure(ex);
        }

        return result;
    }

    private async Task<bool> IsCategoryDuplicate(
        Expression<Func<TblCategory, bool>> expression
    )
    {
        return await _dbContext.TblCategories.AnyAsync(
            expression
        );
    }

    private async Task<TblCategory?> GetSpecificCategory(
        Expression<Func<TblCategory, bool>> expression
    )
    {
        return await _dbContext.TblCategories.FirstOrDefaultAsync(
            expression
        );
    }
}