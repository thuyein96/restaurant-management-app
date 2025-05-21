using RestaurantManagementApp.DbService.Tables;
using RestaurantManagementApp.Dtos.Features.Category;
using RestaurantManagementApp.Dtos.Features.MenuItem;

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

    public static TblCategory ToEntity(this CategoryDto categoryDto)
    {
        return new TblCategory
        {
            CategoryId = categoryDto.CategoryId,
            CategoryName = categoryDto.CategoryName
        };
    }

    public static TblCategory ToEntity(this CreateCategoryDto categoryDto)
    {
        return new TblCategory
        {
            CategoryName = categoryDto.CategoryName
        };
    }

    public static MenuItemDto ToDto(this TblMenuItem dataModel)
    {
        return new MenuItemDto
        {
            MenuItemId = dataModel.MenuItemId,
            MenuItemName = dataModel.MenuItemName,
            Description = dataModel.Description,
            Price = dataModel.Price,
            CategoryId = dataModel.CategoryId,
            Category = dataModel.Category.ToDto()
        };
    }

    public static TblMenuItem ToEntity(this CreateMenuItemDto menuItemDto)
    {
        return new TblMenuItem
        {
            MenuItemName = menuItemDto.MenuItemName,
            Description = menuItemDto.Description,
            Price = menuItemDto.Price,
            CategoryId = menuItemDto.CategoryId,
            Category = menuItemDto.Category.ToEntity()
        };
    }
}