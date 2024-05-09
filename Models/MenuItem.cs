using System;

namespace ServiceSystem.Models
{
    public class MenuItem
{ 
    public int Id { get; set; }
    public string Name { get; set; }
    public int Type { get; set; }
    public int StockQuantity { get; set; }
    public decimal Value { get; set; }
}
}