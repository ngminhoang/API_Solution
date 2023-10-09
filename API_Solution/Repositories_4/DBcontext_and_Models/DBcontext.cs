using Microsoft.EntityFrameworkCore;
namespace API_6._0_4.DBcontext

{
    public class EF_DBcontext : DbContext
    {
        public EF_DBcontext(DbContextOptions<EF_DBcontext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Huyen>()
            //   .HasKey(h => new { h.Tid, h.Hid }); // Composite key configuration
            modelBuilder.Entity<Province>()
           .Property(p => p.provinceID)
           .ValueGeneratedOnAdd();
        }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Ward> Wards { get; set; }
    }
}