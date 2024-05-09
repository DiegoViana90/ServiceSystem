using System;
using ServiceSystem.Models.Enum;

namespace ServiceSystem.Models
{
    public class MenuItem
{ 
    public int Id { get; set; }
    public string Name { get; set; }
    public MenuType MenuType { get; set; }
    public int StockQuantity { get; set; }
    public decimal Value { get; set; }
}
}