using FoodyApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodyApi.Data
{
    public class FoodDbContext : DbContext
    {
        public FoodDbContext(DbContextOptions options):base(options)
        {
        }

        public DbSet<FoodInfo> FoodInfos{ get; set; }
    }
}
