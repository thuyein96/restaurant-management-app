using Microsoft.EntityFrameworkCore;
using RestaurantManagementApp.DbService.Tables;

namespace RestaurantManagementApp.Modules.Features.CustomizeOption;

public class CustomizeOptionService : ICustomizeOptionService
{
    private readonly AppDbContext _dbContext;

    public CustomizeOptionService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Result<IEnumerable<CustomizeOptionDto>>> GetCustomizeOptionsAsync()
    {
        Result<IEnumerable<CustomizeOptionDto>> result;
        try
        {
            var lst = await _dbContext
                .TblCustomizeOptions
                .ToListAsync();
            result = Result<IEnumerable<CustomizeOptionDto>>.Success(lst.Select(x => x.ToDto()));
        }
        catch (Exception ex)
        {
            result = Result<IEnumerable<CustomizeOptionDto>>.Failure(ex);
        }

        return result;
    }

    public async Task<Result<CustomizeOptionDto>> GetCustomizeOptionByIdAsync(Guid id)
    {
        Result<CustomizeOptionDto> result;
        try
        {
            var option = await _dbContext
                .TblCustomizeOptions
                .FirstOrDefaultAsync(x => x.CustomizeOptionId == id);
            result = Result<CustomizeOptionDto>.Success(option.ToDto());
        }
        catch (Exception ex)
        {
            result = Result<CustomizeOptionDto>.Failure(ex);
        }

        return result;
    }

    public async Task<Result<CustomizeOptionDto>> CreateCustomizeOptionAsync(
        CreateCustomizeOptionDto createCustomizeOptionDto
        )
    {
        Result<CustomizeOptionDto> result;
        try
        {
            await _dbContext.TblCustomizeOptions.AddAsync(createCustomizeOptionDto.ToEntity());
            await _dbContext.SaveChangesAsync();
            result = Result<CustomizeOptionDto>.Success();
        }
        catch (Exception ex)
        {
            result = Result<CustomizeOptionDto>.Failure(ex);
        }

        return result;
    }

    public async Task<Result<CustomizeOptionDto>> UpdateCustomizeOptionAsync(
        Guid id, 
        UpdateCustomizeOptionDto updateCustomizeOptionDto
        )
    {
        Result<CustomizeOptionDto> result;
        try
        {
            bool option = await _dbContext.TblCustomizeOptions
                .AnyAsync(x => x.Name == updateCustomizeOptionDto.Name);
            if (option)
            {
                return Result<CustomizeOptionDto>.NotFound("Customize Option Already Exist.");
            }

            var customizeOptionDto = new CustomizeOptionDto
            {
                CustomizeOptionId = id,
                CustomizeOptionName = updateCustomizeOptionDto.Name,
                Price = updateCustomizeOptionDto.Price
            };

            _dbContext.TblCustomizeOptions.Update(customizeOptionDto.ToEntity());
            await _dbContext.SaveChangesAsync();
            result = Result<CustomizeOptionDto>.Success();
        }
        catch (Exception ex)
        {
            result = Result<CustomizeOptionDto>.Failure(ex);
        }

        return result;
    }

    public async Task<Result<CustomizeOptionDto>> DeleteCustomizeOptionAsync(Guid id)
    {
        Result<CustomizeOptionDto> result;
        try
        {
            var customizeOption = await _dbContext.TblCustomizeOptions
                .FirstOrDefaultAsync(x => x.CustomizeOptionId == id);

            if (customizeOption is null)
            {
                return Result<CustomizeOptionDto>.NotFound("Customize Option Not Found.");
            }

            _dbContext.TblCustomizeOptions.Remove(customizeOption);
            await _dbContext.SaveChangesAsync();

            result = Result<CustomizeOptionDto>.DeleteSuccess();
        }
        catch (Exception ex)
        {
            result = Result<CustomizeOptionDto>.Failure(ex);
        }

        return result;
    }
}