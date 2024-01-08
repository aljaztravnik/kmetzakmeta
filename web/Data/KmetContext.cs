using web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace web.Data
{
    public class KmetContext : IdentityDbContext<ApplicationUser>
    {
        public KmetContext(DbContextOptions<KmetContext> options) : base(options)
        {
        }

        public DbSet<Uporabnik> Uporabniki { get; set; }

        public DbSet<Regija> Regije { get; set; }

        public DbSet<Pasma> Pasme { get; set; }

        public DbSet<Znamka> Znamke { get; set; }

        public DbSet<KategorijaStroja> KategorijeStrojev { get; set; }

        public DbSet<OglasStroj> OglasiStrojev { get; set; }

        public DbSet<OglasZivina> OglasiZivine { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Uporabnik>().ToTable("Uporabnik");
            modelBuilder.Entity<Regija>().ToTable("Regija");
            modelBuilder.Entity<Pasma>().ToTable("Pasma");
            modelBuilder.Entity<Znamka>().ToTable("Znamka");
            modelBuilder.Entity<KategorijaStroja>().ToTable("KategorijaStroja");
            modelBuilder.Entity<OglasStroj>().ToTable("OglasStroj");
            modelBuilder.Entity<OglasZivina>().ToTable("OglasZivina");
        }
    }
}