namespace RestaurantManagementApp.Modules.Features.Table;

public class TableService : ITableService
{
    private readonly AppDbContext _dbContext;

    public TableService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Result<IEnumerable<TableDto>>> GetTablesAsync()
    {
        Result<IEnumerable<TableDto>> result;
        try
        {
            var lst = await _dbContext
                .TblTables
                .ToListAsync();
            result = Result<IEnumerable<TableDto>>.Success(lst.Select(x => x.ToDto()));
        }
        catch (Exception ex)
        {
            result = Result<IEnumerable<TableDto>>.Failure(ex);
        }
        return result;
    }

    public async Task<Result<TableDto>> GetTableByIdAsync(Guid tableId)
    {
        Result<TableDto> result;
        try
        {
            var table = await _dbContext
                .TblTables
                .FirstOrDefaultAsync(x => x.Id == tableId);
            if (table is null)
            {
                result = Result<TableDto>.NotFound("Table Not Found.");
                return result;
            }

            result = Result<TableDto>.Success(table.ToDto());
        }
        catch (Exception ex)
        {
            result = Result<TableDto>.Failure(ex);
        }

        return result;
    }

    public async Task<Result<TableDto>> CreateTableAsync(CreateTableDto newTable)
    {
        Result<TableDto> result;
        try
        {
            //check for duplicate table number
            var isDuplicate = await _dbContext
                .TblTables
                .AnyAsync(x => x.TableNumber == newTable.TableNumber);
            if (isDuplicate)
            {
                result = Result<TableDto>.Failure("Duplicate Table Number.");
                return result;
            }

            await _dbContext
                .TblTables
                .AddAsync(newTable.TableNumber.ToEntity());
            await _dbContext.SaveChangesAsync();

            result = Result<TableDto>.Success();
        }
        catch (Exception ex)
        {
            result = Result<TableDto>.Failure(ex);
        }

        return result;
    }

    public async Task<Result<TableDto>> UpdateTableAsync(UpdateTableDto updatetable)
    {
        Result<TableDto> result;
        try
        {
            var table = await _dbContext
                .TblTables
                .FirstOrDefaultAsync(x => x.Id == updatetable.TableId);
            if (table is null)
            {
                result = Result<TableDto>.NotFound("Table Not Found.");
                return result;
            }

            table.IsAvailable = updatetable.Status.Name;
            _dbContext.TblTables.Update(table);
            await _dbContext.SaveChangesAsync();
            result = Result<TableDto>.Success(table.ToDto());
        }
        catch (Exception ex)
        {
            result = Result<TableDto>.Failure(ex);
        }
        return result;
    }

    public async Task<Result<TableDto>> DeleteTableAsync(Guid tableId)
    {
        Result<TableDto> result;
        try
        {
            var table = await _dbContext
                .TblTables
                .FirstOrDefaultAsync(x => x.Id == tableId);
            if (table is null)
            {
                result = Result<TableDto>.NotFound("Table Not Found.");
                return result;
            }
            var removedTable = _dbContext.TblTables.Remove(table);
            await _dbContext.SaveChangesAsync();
            result = Result<TableDto>.DeleteSuccess(removedTable.Entity.ToDto());
        }
        catch (Exception ex)
        {
            result = Result<TableDto>.Failure(ex);
        }

        return result;
    }
}