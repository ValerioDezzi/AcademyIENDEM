using Microsoft.EntityFrameworkCore;

namespace GestioneEsa.Models
{
    public class EsaContext : DbContext
    {
        public EsaContext(DbContextOptions<EsaContext> options):base(options)
        {
        }
        public DbSet<ContenitoreCeleste> ContenitoreCelestes { get; set; }
        public DbSet<OggettoCeleste> OggettoCelestes { get; set; }
        public DbSet<OggettoContenitore> OggettoContenitores { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OggettoContenitore>().HasKey(i => new { i.ContenitoreRif, i.OggettoRif });

            modelBuilder.Entity<OggettoContenitore>()
                .HasOne(os => os.oggetto)
                .WithMany(o => o.ElencoOggCont)
                .HasForeignKey(os => os.OggettoRif);

            modelBuilder.Entity<OggettoContenitore>()
               .HasOne(os => os.con)
               .WithMany(s => s.ElencoOggSis)
               .HasForeignKey(os => os.ContenitoreRif);
        }
    }
}

