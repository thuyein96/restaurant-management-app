namespace RestaurantManagementApp.Modules.Features.Menu;

public class MenuItemService : IMenuItemService
{
    private readonly AppDbContext _dbContext;

    public MenuItemService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result<IEnumerable<MenuItemDto>>> GetMenuItemsAsync()
    {
        Result<IEnumerable<MenuItemDto>> result;
        try
        {
            var lst = await _dbContext.TblMenuItems
                .Include(f => f.Category)
                           .Include(f => f.MenuItemCustomizeOptions)
                           .ThenInclude(j => j.CustomizeOption)
                           .ToListAsync();

            if (lst is null || lst.Count == 0)
            {
                result = Result<IEnumerable<MenuItemDto>>.NotFound("Menu Item Not Found.");
                return result;
            }

            result = Result<IEnumerable<MenuItemDto>>.Success(lst.Select(x => x.ToDto()));
        }
        catch (Exception ex)
        {
            result = Result<IEnumerable<MenuItemDto>>.Failure(ex);
        }

    result:
        return result;
    }

    public async Task<Result<MenuItemDto>> GetMenuItemByIdAsync(Guid menuItemId)
    {
        Result<MenuItemDto> result;
        try
        {
            var menuItem = await _dbContext.TblMenuItems.Include(f => f.Category)
                .Include(f => f.MenuItemCustomizeOptions)
                .ThenInclude(j => j.CustomizeOption)
                .FirstOrDefaultAsync(x => x.MenuItemId == menuItemId);

            if (menuItem is null)
            {
                return Result<MenuItemDto>.NotFound("Menu Item Not Found.");
            }

            result = Result<MenuItemDto>.Success(menuItem.ToDto());
        }
        catch (Exception ex)
        {
            result = Result<MenuItemDto>.Failure(ex);
        }

        return result;
    }

    public async Task<Result<MenuItemDto>> CreateMenuItemAsync(CreateMenuItemDto menuItemDto)
    {
        Result<MenuItemDto> result;
        try
        {
            bool isDuplicate = await IsMenuItemDuplicate(
                x => x.MenuItemName == menuItemDto.MenuItemName
            );
            if (isDuplicate)
            {
                result = Result<MenuItemDto>.Duplicate("Menu Item Name already exists.");
                return result;
            }

            await _dbContext.TblMenuItems.AddAsync(menuItemDto.ToEntity());
            await _dbContext.SaveChangesAsync();

            result = Result<MenuItemDto>.SaveSuccess();
        }
        catch (Exception ex)
        {
            result = Result<MenuItemDto>.Failure(ex);
        }

        return result;
    }

    public async Task<Result<MenuItemDto>> UpdateMenuItemAsync(Guid menuItemId, UpdateMenuItemDto menuItemDto)
    {
        Result<MenuItemDto> result;
        try
        {
            var menuItem = await GetSpecificMenuItem(x => x.MenuItemId == menuItemId);
            if (menuItem is null)
            {
                result = Result<MenuItemDto>.NotFound("Menu Item Not Found.");
                return result;
            }

            bool isDuplicate = await IsMenuItemDuplicate(
                x => x.MenuItemName == menuItemDto.MenuItemName && x.MenuItemId != menuItemId
            );
            if (isDuplicate)
            {
                result = Result<MenuItemDto>.Duplicate("Menu Item Name already exists.");
                return result;
            }

            menuItem.MenuItemName = menuItemDto.MenuItemName;
            menuItem.Description = menuItemDto.Description;
            menuItem.Price = menuItemDto.Price;
            menuItem.ImageUrl = menuItemDto.ImageUrl;

            _dbContext.TblMenuItems.Update(menuItem);
            await _dbContext.SaveChangesAsync();

            result = Result<MenuItemDto>.UpdateSuccess();
        }
        catch (Exception ex)
        {
            result = Result<MenuItemDto>.Failure(ex);
        }

        return result;
    }

    public async Task<Result<string>> AddMenuItemCategoryAsync(Guid menuitemid, Guid categoryId)
    {
        Result<string> result;
        try
        {
            var menuItem = await GetSpecificMenuItem(
                x => x.MenuItemId == menuitemid
            );
            if (menuItem is null)
            {
                result = Result<string>.NotFound("Menu Item Not Found.");
                return result;
            }

            var category = await _dbContext.TblCategories.FirstOrDefaultAsync(
                x => x.CategoryId == categoryId
            );
            if (category is null)
            {
                result = Result<string>.NotFound("Category Not Found.");
                return result;
            }

            menuItem.CategoryId = categoryId;
            _dbContext.TblMenuItems.Update(menuItem);
            await _dbContext.SaveChangesAsync();

            result = Result<string>.UpdateSuccess($"Category {category.CategoryName} Added Successfully.");
        }
        catch (Exception ex)
        {
            result = Result<string>.Failure(ex);
        }

        return result;
    }

    public async Task<Result<string>> RemoveMenuItemCategoryAsync(Guid menuitemid)
    {
        Result<string> result;
        try
        {
            var menuItem = await GetSpecificMenuItem(
                x => x.MenuItemId == menuitemid
            );
            if (menuItem is null)
            {
                result = Result<string>.NotFound("Menu Item Not Found.");
                return result;
            }

            menuItem.CategoryId = null;
            _dbContext.TblMenuItems.Update(menuItem);
            await _dbContext.SaveChangesAsync();

            result = Result<string>.UpdateSuccess("Category Removed Successfully.");
        }
        catch (Exception ex)
        {
            result = Result<string>.Failure(ex);
        }

        return result;
    }

    public async Task<Result<string>> AddCustomizeOptionsToMenuAsync(Guid menuitemid, Guid customizeOptionsId)
    {
        Result<string> result;
        try
        {
            var menuItem = await _dbContext.TblMenuItems.Include(f => f.Category)
                .Include(f => f.MenuItemCustomizeOptions)
                .ThenInclude(j => j.CustomizeOption)
                .FirstOrDefaultAsync(x => x.MenuItemId == menuitemid);
            if (menuItem is null)
            {
                result = Result<string>.NotFound("Menu Item Not Found.");
                return result;
            }

            // if menuitem has empty customize options, initialize it or else add to list
            if (menuItem.MenuItemCustomizeOptions is null)
            {
                menuItem.MenuItemCustomizeOptions = new List<TblMenuItemCustomizeOption>();
            }
            else
            {
                var isOptionsExist = await IsCustomizeOptionsExist(customizeOptionsId);
                if (isOptionsExist is false)
                {
                    result = Result<string>.NotFound("Customize Options not found.");
                    return result;
                }

                // Check for duplicates in existing the menu item's customize options
                var isDuplicated = IsOptionsDuplicate(customizeOptionsId, menuItem);
                if (isDuplicated)
                {
                    result = Result<string>.Duplicate("Customize Options already exist for this Menu Item.");
                    return result;
                }
            }

            menuItem.MenuItemCustomizeOptions.Add(new TblMenuItemCustomizeOption
            {
                MenuItemId = menuitemid,
                CustomizeOptionId = customizeOptionsId
            });

            _dbContext.TblMenuItems.Update(menuItem);
            await _dbContext.SaveChangesAsync();

            result = Result<string>.UpdateSuccess("Customize Options Added Successfully.");
        }
        catch (Exception ex)
        {
            result = Result<string>.Failure(ex);
        }

        return result;
    }

    public async Task<Result<string>> RemoveCustomizeOptionsFromMenuAsync(Guid menuitemid, Guid customizeOptionsIds)
    {
        Result<string> result;
        try
        {
            var menuItem = await _dbContext.TblMenuItems.Include(f => f.Category)
                .Include(f => f.MenuItemCustomizeOptions)
                .ThenInclude(j => j.CustomizeOption)
                .FirstOrDefaultAsync(x => x.MenuItemId == menuitemid);
            if (menuItem is null)
            {
                result = Result<string>.NotFound("Menu Item Not Found.");
                return result;
            }
            var customizeOption = menuItem.MenuItemCustomizeOptions
                .FirstOrDefault(x => x.CustomizeOptionId == customizeOptionsIds);
            if (customizeOption is null)
            {
                result = Result<string>.NotFound("Customize Options not found for this Menu Item.");
                return result;
            }
            menuItem.MenuItemCustomizeOptions.Remove(customizeOption);
            _dbContext.TblMenuItems.Update(menuItem);
            await _dbContext.SaveChangesAsync();
            result = Result<string>.UpdateSuccess("Customize Options Removed Successfully.");
        }
        catch (Exception ex)
        {
            result = Result<string>.Failure(ex);
        }
        return result;
    }

    public async Task<Result<MenuItemDto>> DeleteMenuItemAsync(Guid menuItemId)
    {
        Result<MenuItemDto> result;
        try
        {
            var menuItem = await _dbContext.TblMenuItems.Include(f => f.Category)
                .Include(f => f.MenuItemCustomizeOptions)
                .ThenInclude(j => j.CustomizeOption)
                .FirstOrDefaultAsync(x => x.MenuItemId == menuItemId);
            if (menuItem is null)
            {
                result = Result<MenuItemDto>.NotFound("Menu Item Not Found.");
                return result;
            }

            _dbContext.TblMenuItemCustomizeOptions
                .RemoveRange(menuItem.MenuItemCustomizeOptions);
            _dbContext.TblMenuItems.Remove(menuItem);
            await _dbContext.SaveChangesAsync();

            result = Result<MenuItemDto>.DeleteSuccess();
        }
        catch (Exception ex)
        {
            result = Result<MenuItemDto>.Failure(ex);
        }
        return result;
    }



    private bool IsOptionsDuplicate(Guid customizeOptionsIds, TblMenuItem menuItem)
    {
        var isDuplicated = menuItem.MenuItemCustomizeOptions
            .Any(x => x.CustomizeOptionId == customizeOptionsIds);
        return isDuplicated;
    }

    private async Task<bool> IsCustomizeOptionsExist(Guid customizeOptionsId)
    {
        return await _dbContext.TblCustomizeOptions.AnyAsync(
            x => x.CustomizeOptionId == customizeOptionsId
        );
    }

    private async Task<bool> IsMenuItemDuplicate(
        Expression<Func<TblMenuItem, bool>> expression
    )
    {
        return await _dbContext.TblMenuItems.AnyAsync(
            expression
        );
    }

    private async Task<TblMenuItem?> GetSpecificMenuItem(
        Expression<Func<TblMenuItem, bool>> expression
    )
    {
        return await _dbContext.TblMenuItems.FirstOrDefaultAsync(
            expression
        );
    }


}