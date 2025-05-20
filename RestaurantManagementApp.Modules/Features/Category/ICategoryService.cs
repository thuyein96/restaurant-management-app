using RestaurantManagementApp.Dtos.Features.Category;

namespace RestaurantManagementApp.Modules.Features.Category;

public interface ICategoryService
{
    Task<Result<IEnumerable<CategoryDto>>> GetCategoriesAsync();
    Task<Result<CategoryDto>> GetCategoryByIdAsync(
        Guid categoryId
        
    );
    Task<Result<CategoryDto>> CreateCategoryAsync(
        CreateCategoryDto categoryDto
        
    );
    Task<Result<CategoryDto>> DeleteCategoryAsync(
        Guid categoryId
        
    );
}