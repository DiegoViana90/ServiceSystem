using ServiceSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ServiceSystem.Data
{
    public class AppDbContext : DbContext{
    public DbSet<Order> Orders { get; set; }
    }
}