using Microsoft.EntityFrameworkCore;

namespace SimpleCqrs.DataAccess
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Product> Product { get; set; }

        public virtual DbSet<ProductCategory> ProductCategory { get; set; }

        public virtual DbSet<Category> Category { get; set; }
    }
}
