﻿namespace RestaurantManagementApp.Dtos.Features.Cart;

public class CartItemDto
{
    public Guid CartItemId { get; set; }
    public Guid CartId { get; set; }
    public CartDto Cart { get; set; }
    public Guid MenuItemId { get; set; }
    public MenuItemDto MenuItem { get; set; }
    public int Quantity { get; set; }
}