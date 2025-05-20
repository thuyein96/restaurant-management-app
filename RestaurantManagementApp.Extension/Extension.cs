using RestaurantManagementApp.DbService.Tables;
using RestaurantManagementApp.Dtos.Features.Category;

namespace RestaurantManagementApp.Extension;

public static class Extension
{
    public static CategoryDto ToDto(this TblCategory dataModel)
    {
        return new CategoryDto
        {
            CategoryId = dataModel.CategoryId,
            CategoryName = dataModel.CategoryName
        };
    }

    public static TblCategory ToEntity(this CreateCategoryDto categoryDto)
    {
        return new TblCategory
        {
            CategoryName = categoryDto.CategoryName
        };
    }
}