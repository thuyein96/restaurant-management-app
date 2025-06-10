namespace RestaurantManagementApp.Extension.Mapping.Table;

public static class TableMapper
{
    public static TableDto ToDto(this TblTable dataModel)
    {
        return new TableDto
        {
            Id = dataModel.Id,
            TableNumber = dataModel.TableNumber,
            IsAvailable = TableStatus.FromName(dataModel.IsAvailable, ignoreCase: true)
        };
    }

    public static TblTable ToEntity(this TableDto tableDto)
    {
        return new TblTable
        {
            TableNumber = tableDto.TableNumber,
            IsAvailable = tableDto.IsAvailable.Name
        };
    }

    public static TblTable ToEntity(this string tableNumber)
    {
        return new TblTable
        {
            TableNumber = tableNumber,
            IsAvailable = TableStatus.Available.Name
        };
    }
}
