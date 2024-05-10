using ServiceSystem.Models;
using ServiceSystem.Models.Enum;
using System;
using System.Collections.Generic;
public class Order
{
    public int OrderId { get; set; }
    public bool OrderStatus { get; set; }
    public int TableNumber { get; set; }
    public DateTime CreationDate { get; set; }
    public decimal TotalValue { get; set; }
    public List<OrderItem> OrderItems { get; set; }
    public DateTime? ClosedDate { get; set; }
    public OrderItemType OrderItemType { get; set; }
}