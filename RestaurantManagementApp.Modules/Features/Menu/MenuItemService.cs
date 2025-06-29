﻿namespace RestaurantManagementApp.Modules.Features.Menu;

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
            var menuItem = await GetSpecificMenuItem(
                x => x.MenuItemId == menuItemId
            );
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

            _dbContext.TblMenuItems.Update(menuItem);
            await _dbContext.SaveChangesAsync();

            result = Result<MenuItemDto>.UpdateSuccess();
        }
        catch (Exception ex)
        {
            result = Result<MenuItemDto>.Failure(ex);
        }

        result:
        return result;
    }

    public async Task<Result<MenuItemDto>> DeleteMenuItemAsync(Guid menuItemId)
    {
        Result<MenuItemDto> result;
        try
        {
            var menuItem = await GetSpecificMenuItem(
                x => x.MenuItemId == menuItemId
            );
            if (menuItem is null)
            {
                result = Result<MenuItemDto>.NotFound("Menu Item Not Found.");
                return result;
            }

            _dbContext.TblMenuItems.Remove(menuItem);
            await _dbContext.SaveChangesAsync();

            result = Result<MenuItemDto>.DeleteSuccess();
        }
        catch (Exception ex)
        {
            result = Result<MenuItemDto>.Failure(ex);
        }

        result:
        return result;
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