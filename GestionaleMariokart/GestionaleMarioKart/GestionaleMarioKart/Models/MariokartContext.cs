using Microsoft.EntityFrameworkCore;

namespace GestionaleMarioKart.Models
{
    public class MariokartContext: DbContext
    {
        public MariokartContext(DbContextOptions<MariokartContext>options):base(options) { }
        public DbSet<Giocatore> Giocatores { get; set; }
        public DbSet<Personaggio> Personaggios { get; set; }
        public DbSet<Squadra> Squadras { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            {
                modelBuilder.Entity<Squadra>()
                    .HasOne(s => s.Giocatore)
                    .WithOne(g => g.Squadra)
                    .HasForeignKey<Squadra>(s => s.GiocatoreRif);

                modelBuilder.Entity<Squadra>()
                    .HasOne(s => s.Personaggio50)
                    .WithMany()
                    .HasForeignKey(s => s.Personaggio50Rif);

                modelBuilder.Entity<Squadra>()
                    .HasOne(s => s.Personaggio100)
                    .WithMany()
                    .HasForeignKey(s => s.Personaggio100Rif);

                modelBuilder.Entity<Squadra>()
                    .HasOne(s => s.Personaggio150)
                    .WithMany()
                    .HasForeignKey(s => s.Personaggio150Rif);
            }


        }
    }
}
