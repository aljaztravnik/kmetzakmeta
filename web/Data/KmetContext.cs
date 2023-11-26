using web.Models;
using Microsoft.EntityFrameworkCore;

namespace web.Data
{
    public class KmetContext : DbContext
    {
        public KmetContext(DbContextOptions<KmetContext> options) : base(options)
        {
        }

        public DbSet<Uporabnik> Uporabniki { get; set; }

        public DbSet<Regija> Regije { get; set; }

        public DbSet<Pasma> Pasme { get; set; }

        public DbSet<Znamka> Znamke { get; set; }

        public DbSet<KategorijaStroja> KategorijeStrojev { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Uporabnik>().ToTable("Uporabnik");
            modelBuilder.Entity<Regija>().ToTable("Regija");
            modelBuilder.Entity<Pasma>().ToTable("Pasma");
            modelBuilder.Entity<Znamka>().ToTable("Znamka");
            modelBuilder.Entity<KategorijaStroja>().ToTable("KategorijaStroja");
        }
    }
}