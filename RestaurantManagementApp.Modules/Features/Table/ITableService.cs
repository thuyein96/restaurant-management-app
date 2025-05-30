namespace RestaurantManagementApp.Modules.Features.Table;

public interface ITableService
{
    Task<Result<IEnumerable<TableDto>>> GetTablesAsync();
    Task<Result<TableDto>> GetTableByIdAsync(Guid tableId);
    Task<Result<TableDto>> CreateTableAsync(string tableNumber);
    Task<Result<TableDto>> UpdateTableAsync(Guid tableId, TableStatus tableStatus);
    Task<Result<TableDto>> DeleteTableAsync(Guid tableId);

}