using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace JustDezziAPI.Models;

public partial class JustDezziContext : DbContext
{
    public JustDezziContext()
    {
    }

    public JustDezziContext(DbContextOptions<JustDezziContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Carrello> Carrellos { get; set; }

    public virtual DbSet<CarrelloPiatto> CarrelloPiattos { get; set; }

    public virtual DbSet<Ordinazione> Ordinaziones { get; set; }

    public virtual DbSet<Piatto> Piattos { get; set; }

    public virtual DbSet<Ristorante> Ristorantes { get; set; }

    public virtual DbSet<Utente> Utentes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS01;Database=JustDezzi;User Id=academy;Password=academy!;MultipleActiveResultSets=true;Encrypt=false;TrustServerCertificate=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Carrello>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Carrello__3214EC2768D2B8CB");

            entity.ToTable("Carrello");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.UtenteRif).HasColumnName("utenteRIF");

            entity.HasOne(d => d.UtenteRifNavigation).WithMany(p => p.Carrellos)
                .HasForeignKey(d => d.UtenteRif)
                .HasConstraintName("FK__Carrello__utente__48CFD27E");
        });

        modelBuilder.Entity<CarrelloPiatto>(entity =>
        {
            entity.HasKey(e => new { e.CarrelloRif, e.PiattoRif }).HasName("PK__Carrello__4258B01232846F95");

            entity.ToTable("Carrello_Piatto");

            entity.Property(e => e.CarrelloRif).HasColumnName("carrelloRIF");
            entity.Property(e => e.PiattoRif).HasColumnName("piattoRIF");
            entity.Property(e => e.Quantita).HasColumnName("quantita");

            entity.HasOne(d => d.CarrelloRifNavigation).WithMany(p => p.CarrelloPiattos)
                .HasForeignKey(d => d.CarrelloRif)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Carrello___carre__4BAC3F29");

            entity.HasOne(d => d.PiattoRifNavigation).WithMany(p => p.CarrelloPiattos)
                .HasForeignKey(d => d.PiattoRif)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Carrello___piatt__4CA06362");
        });

        modelBuilder.Entity<Ordinazione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ordinazi__3214EC27C1111A80");

            entity.ToTable("Ordinazione");

            entity.HasIndex(e => e.Codice, "UQ__Ordinazi__40F9C18B3C23D74B").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CarrelloRif).HasColumnName("carrelloRIF");
            entity.Property(e => e.Codice)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("codice");
            entity.Property(e => e.DataOra)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("data_ora");
            entity.Property(e => e.Istruzioni)
                .HasDefaultValue("N.D")
                .HasColumnType("text")
                .HasColumnName("istruzioni");
            entity.Property(e => e.RistoranteRif).HasColumnName("ristoranteRIF");
            entity.Property(e => e.Stato)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("stato");
            entity.Property(e => e.UtenteRif).HasColumnName("utenteRIF");

            entity.HasOne(d => d.CarrelloRifNavigation).WithMany(p => p.Ordinaziones)
                .HasForeignKey(d => d.CarrelloRif)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ordinazio__carre__02FC7413");

            entity.HasOne(d => d.RistoranteRifNavigation).WithMany(p => p.Ordinaziones)
                .HasForeignKey(d => d.RistoranteRif)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ordinazio__risto__03F0984C");

            entity.HasOne(d => d.UtenteRifNavigation).WithMany(p => p.Ordinaziones)
                .HasForeignKey(d => d.UtenteRif)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ordinazio__utent__02084FDA");
        });

        modelBuilder.Entity<Piatto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Piatto__3214EC27CFE79004");

            entity.ToTable("Piatto");

            entity.HasIndex(e => e.Codice, "UQ__Piatto__40F9C18B78CA5910").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Codice)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("codice");
            entity.Property(e => e.Descrizione)
                .HasColumnType("text")
                .HasColumnName("descrizione");
            entity.Property(e => e.Nome)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.Prezzo)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("prezzo");
            entity.Property(e => e.RistoranteRif).HasColumnName("ristoranteRIF");

            entity.HasOne(d => d.RistoranteRifNavigation).WithMany(p => p.Piattos)
                .HasForeignKey(d => d.RistoranteRif)
                .HasConstraintName("FK__Piatto__ristoran__45F365D3");
        });

        modelBuilder.Entity<Ristorante>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ristoran__3214EC275C77FB91");

            entity.ToTable("Ristorante");

            entity.HasIndex(e => e.Codice, "UQ__Ristoran__40F9C18BC1E60B8F").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Apertura).HasColumnName("apertura");
            entity.Property(e => e.Chiusura).HasColumnName("chiusura");
            entity.Property(e => e.Codice)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("codice");
            entity.Property(e => e.Indirizzo)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("indirizzo");
            entity.Property(e => e.Nome)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.Tipo)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<Utente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Utente__3214EC2737FD0A44");

            entity.ToTable("Utente");

            entity.HasIndex(e => e.Nome, "UQ__Utente__6F71C0DCEC797937").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Utente__AB6E6164B79C9B07").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Indirizzo)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("indirizzo");
            entity.Property(e => e.Nome)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.Pass)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("pass");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
