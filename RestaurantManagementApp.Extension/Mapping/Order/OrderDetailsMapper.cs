namespace RestaurantManagementApp.Extension.Mapping.Order;

public static class OrderDetailsMapper
{
    public static TblOrderDetails ToEntity(this OrderDetailsDto datamodel)
    {
        return new TblOrderDetails
        {
            Id = datamodel.Id,
            OrderId = datamodel.OrderId,
            MenuItemId = datamodel.MenuItemId,
            UnitPrice = datamodel.UnitPrice,
            SubTotal = datamodel.SubTotal,
            Quantity = datamodel.Quantity
        };
    }

    public static OrderDetailsDto ToDto(this TblOrderDetails entity)
    {
        return new OrderDetailsDto
        {
            Id = entity.Id,
            OrderId = entity.OrderId,
            MenuItemId = entity.MenuItemId,
            UnitPrice = entity.UnitPrice,
            SubTotal = entity.SubTotal,
            Quantity = entity.Quantity
        };
    }

    public static TblOrderDetails ToEntity(this CreateOrderDetailsDto datamodel)
    {
        return new TblOrderDetails
        {
            OrderId = datamodel.OrderId,
            MenuItemId = datamodel.MenuItemId,
            UnitPrice = datamodel.UnitPrice,
            SubTotal = datamodel.SubTotal,
            Quantity = datamodel.Quantity
        };
    }
}