﻿namespace RestaurantManagementApp.Dtos.Features.Table;

public class TableDto
{
    public Guid Id { get; set; }
    public string TableNumber { get; set; }
    public TableStatus IsAvailable { get; set; }
}