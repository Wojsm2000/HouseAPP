using Microsoft.EntityFrameworkCore;

namespace House.Domain
{
    public class HouseContext : DbContext
    {
        public HouseContext(DbContextOptions<HouseContext> options) : base(options)
        {

        }

        public DbSet<Domain.Models.House> Houses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Models.House>().ToTable("House");
        }
    }
}
