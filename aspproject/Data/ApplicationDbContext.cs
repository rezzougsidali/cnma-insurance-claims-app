using aspproject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace aspproject.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser , IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Define DbSet for each table (model)
       
        public DbSet<assure> assure { get; set; }
        public DbSet<synthese_volet_sinistre> synthese_volet_sinistre { get; set; }
    }
}
