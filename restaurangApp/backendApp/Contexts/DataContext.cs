using backendApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace backendApp.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<DishEntity> Dishes { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
    }
}
