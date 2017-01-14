using CoreWEBAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreWEBAPI.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<BillModel> Bills { get; set; }
        public DbSet<CompanyModel> Companies { get; set; }
        public DbSet<ProductModel> Products { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}