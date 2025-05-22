namespace RestaurantManagementApp.Modules.Features.CustomizeOption;

public interface ICustomizeOptionService
{
    Task<Result<IEnumerable<CustomizeOptionDto>>> GetCustomizeOptionsAsync();
    Task<Result<CustomizeOptionDto>> GetCustomizeOptionByIdAsync(Guid id);
    Task<Result<CustomizeOptionDto>> CreateCustomizeOptionAsync(CreateCustomizeOptionDto createCustomizeOptionDto);
    Task<Result<CustomizeOptionDto>> UpdateCustomizeOptionAsync(Guid id, UpdateCustomizeOptionDto updateCustomizeOptionDto);
    Task<Result<CustomizeOptionDto>> DeleteCustomizeOptionAsync(Guid id);
}