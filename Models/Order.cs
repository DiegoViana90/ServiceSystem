using System;

namespace ServiceSystem.Models
{
public class Order
{ 
    public int Id { get; set; }
    public string Title { get; set; }
    public bool Done { get; set; }
    public DateTime CreationDate { get; set; } = DateTime.Now;
}
}