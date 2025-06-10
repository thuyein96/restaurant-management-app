namespace RestaurantManagementApp.Extension.Mapping.Order;

public static class OrderMapper
{
    public static TblOrder ToEntity(this OrderDto datamodel)
    {
        return new TblOrder
        {
            Id = datamodel.Id,
            CustomerId = datamodel.CustomerId,
            OrderDate = datamodel.OrderDate,
            OrderDetails = datamodel.OrderDetails.Select(x => x.ToEntity()).ToList()
        };
    }

    public static TblOrder ToEntity(this CreateOrderDto datamodel)
    {
        return new TblOrder
        {
            CustomerId = datamodel.CustomerId,
            OrderDate = datamodel.OrderDate,
            OrderDetails = datamodel.OrderItems.Select(x => x.ToEntity()).ToList()
        };
    }

    public static TblOrder ToEntity(this UpdateOrderDto datamodel)
    {
        return new TblOrder
        {
            Id = datamodel.OrderId,
            CustomerId = datamodel.CustomerId,
            OrderDate = datamodel.OrderDate,
            TotalAmount = datamodel.TotalAmount,
            OrderDetails = datamodel.OrderItems.Select(x => x.ToEntity()).ToList()
        };
    }

    public static OrderDto ToDto(this TblOrder entity)
    {
        return new OrderDto
        {
            Id = entity.Id,
            CustomerId = entity.CustomerId,
            OrderDate = entity.OrderDate,
            TotalAmount = entity.TotalAmount,
            OrderDetails = entity.OrderDetails.Select(x => x.ToDto()).ToList()
        };
    }
}