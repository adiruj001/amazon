using Microsoft.EntityFrameworkCore;
using BaseRestApi.Models;

namespace BaseRestApi.Data
{
    public class BaseRestApiContext : DbContext
    {
        public BaseRestApiContext(DbContextOptions<BaseRestApiContext> options) : base(options)
        {
        }

        public DbSet<PointOfPurchase> PointOfPurchases { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
