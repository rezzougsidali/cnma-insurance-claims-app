using aspproject.Models;
using aspproject.Models.c;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace aspproject.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }
        public DbSet<garantie> garantie { get; set; }
        public DbSet<detail_contrat> detail_contrat { get; set; }
        public DbSet<crma> crma { get; set; }
        public DbSet<branche> branche { get; set; }
        public DbSet<synthese_contrat> synthese_contrat { get; set; }
        public DbSet<detail_sinistre> detail_sinistre { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<detail_contrat>().ToTable("detail_contrat");
            modelBuilder.Entity<garantie>().ToTable("garantie");
            modelBuilder.Entity<crma>().ToTable("crma");
            modelBuilder.Entity<branche>().ToTable("branche");
            modelBuilder.Entity<synthese_contrat>().ToTable("synthese_contrat");

            // Configure the relationship between detail_contrat and garantie (assumed)
            modelBuilder.Entity<detail_contrat>()
                .HasMany(dc => dc.Garanties)
                .WithOne()
                .HasForeignKey(g => g.ContratId);
    }

    }
}
