using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GestFerrAuth.Models;

public partial class FerramentaContext : DbContext
{
    public FerramentaContext()
    {
    }

    public FerramentaContext(DbContextOptions<FerramentaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Prodotto> Prodottos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS01;Database=Ferramenta;User Id=academy;Password=academy!;MultipleActiveResultSets=true;Encrypt=false;TrustServerCertificate=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Prodotto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Prodotto__3214EC27E2C97024");

            entity.ToTable("Prodotto");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Categoria)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("categoria");
            entity.Property(e => e.Codice)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("codice");
            entity.Property(e => e.DataCreazione)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("data_creazione");
            entity.Property(e => e.Descrizione)
                .HasColumnType("text")
                .HasColumnName("descrizione");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.Prezzo)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("prezzo");
            entity.Property(e => e.Quantita).HasColumnName("quantita");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
