namespace RestaurantManagementApp.Modules.Features.Table;

public interface ITableService
{
    Task<Result<IEnumerable<TableDto>>> GetTablesAsync();
    Task<Result<TableDto>> GetTableByIdAsync(Guid tableId);
    Task<Result<TableDto>> CreateTableAsync(CreateTableDto newTable);
    Task<Result<TableDto>> UpdateTableAsync(UpdateTableDto updatetable);
    Task<Result<TableDto>> DeleteTableAsync(Guid tableId);

}