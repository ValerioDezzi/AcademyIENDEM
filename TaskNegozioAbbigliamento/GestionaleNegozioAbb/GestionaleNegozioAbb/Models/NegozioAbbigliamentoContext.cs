using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GestionaleNegozioAbb.Models;

public partial class NegozioAbbigliamentoContext : DbContext
{
    public NegozioAbbigliamentoContext()
    {
    }

    public NegozioAbbigliamentoContext(DbContextOptions<NegozioAbbigliamentoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorie> Categories { get; set; }

    public virtual DbSet<DettagliOrdini> DettagliOrdinis { get; set; }

    public virtual DbSet<Ordini> Ordinis { get; set; }

    public virtual DbSet<Prodotti> Prodottis { get; set; }

    public virtual DbSet<Utenti> Utentis { get; set; }

    public virtual DbSet<VariazioniProdotti> VariazioniProdottis { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS01;Database=NegozioAbbigliamento;User Id=academy;Password=academy!;MultipleActiveResultSets=true;Encrypt=false;TrustServerCertificate=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorie>(entity =>
        {
            entity.HasKey(e => e.CategoriaId).HasName("PK__Categori__6378C0207B729361");

            entity.ToTable("Categorie");

            entity.HasIndex(e => e.Nome, "UQ__Categori__6F71C0DCBEB40D01").IsUnique();

            entity.Property(e => e.CategoriaId).HasColumnName("categoriaID");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<DettagliOrdini>(entity =>
        {
            entity.HasKey(e => e.DettaglioId).HasName("PK__Dettagli__EF0172F50456D1F2");

            entity.ToTable("DettagliOrdini");

            entity.Property(e => e.DettaglioId).HasColumnName("dettaglioID");
            entity.Property(e => e.OrdineRif).HasColumnName("ordineRIF");
            entity.Property(e => e.Quantita).HasColumnName("quantita");
            entity.Property(e => e.VariazioneRif).HasColumnName("variazioneRIF");

            entity.HasOne(d => d.OrdineRifNavigation).WithMany(p => p.DettagliOrdinis)
                .HasForeignKey(d => d.OrdineRif)
                .HasConstraintName("FK__DettagliO__ordin__4D94879B");

            entity.HasOne(d => d.VariazioneRifNavigation).WithMany(p => p.DettagliOrdinis)
                .HasForeignKey(d => d.VariazioneRif)
                .HasConstraintName("FK__DettagliO__varia__4E88ABD4");
        });

        modelBuilder.Entity<Ordini>(entity =>
        {
            entity.HasKey(e => e.OrdineId).HasName("PK__Ordini__8F87D0E55E4653DB");

            entity.ToTable("Ordini");

            entity.Property(e => e.OrdineId).HasColumnName("ordineID");
            entity.Property(e => e.DataOrdine)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("data_ordine");
            entity.Property(e => e.UtenteRif).HasColumnName("utenteRIF");

            entity.HasOne(d => d.UtenteRifNavigation).WithMany(p => p.Ordinis)
                .HasForeignKey(d => d.UtenteRif)
                .HasConstraintName("FK__Ordini__utenteRI__403A8C7D");
        });

        modelBuilder.Entity<Prodotti>(entity =>
        {
            entity.HasKey(e => e.ProdottoId).HasName("PK__Prodotti__3AB6597541A5846A");

            entity.ToTable("Prodotti");

            entity.Property(e => e.ProdottoId).HasColumnName("prodottoID");
            entity.Property(e => e.Descrizione)
                .HasColumnType("text")
                .HasColumnName("descrizione");
            entity.Property(e => e.ImmagineUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("immagineURL");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nome");

            entity.HasMany(d => d.CategoriaRifs).WithMany(p => p.ProdottoRifs)
                .UsingEntity<Dictionary<string, object>>(
                    "ProdottiCategorie",
                    r => r.HasOne<Categorie>().WithMany()
                        .HasForeignKey("CategoriaRif")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Prodotti___categ__46E78A0C"),
                    l => l.HasOne<Prodotti>().WithMany()
                        .HasForeignKey("ProdottoRif")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Prodotti___prodo__45F365D3"),
                    j =>
                    {
                        j.HasKey("ProdottoRif", "CategoriaRif").HasName("PK__Prodotti__46E1E8D6F1852B9E");
                        j.ToTable("Prodotti_Categorie");
                        j.IndexerProperty<int>("ProdottoRif").HasColumnName("prodottoRIF");
                        j.IndexerProperty<int>("CategoriaRif").HasColumnName("categoriaRIF");
                    });
        });

        modelBuilder.Entity<Utenti>(entity =>
        {
            entity.HasKey(e => e.UtenteId).HasName("PK__Utenti__CA5C2253726A9214");

            entity.ToTable("Utenti");

            entity.HasIndex(e => e.Email, "UQ__Utenti__AB6E61646414207B").IsUnique();

            entity.Property(e => e.UtenteId).HasColumnName("utenteID");
            entity.Property(e => e.Cognome)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cognome");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<VariazioniProdotti>(entity =>
        {
            entity.HasKey(e => e.VariazioneId).HasName("PK__Variazio__54F6EA5A7417F7DA");

            entity.ToTable("VariazioniProdotti");

            entity.Property(e => e.VariazioneId).HasColumnName("variazioneID");
            entity.Property(e => e.Colore)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("colore");
            entity.Property(e => e.DataFineOfferta)
                .HasColumnType("datetime")
                .HasColumnName("dataFineOfferta");
            entity.Property(e => e.DataInizioOfferta)
                .HasColumnType("datetime")
                .HasColumnName("dataInizioOfferta");
            entity.Property(e => e.PrezzoOfferta)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("prezzoOfferta");
            entity.Property(e => e.PrezzoPieno)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("prezzoPieno");
            entity.Property(e => e.ProdottoRif).HasColumnName("prodottoRIF");
            entity.Property(e => e.Quantita).HasColumnName("quantita");
            entity.Property(e => e.Taglia)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("taglia");

            entity.HasOne(d => d.ProdottoRifNavigation).WithMany(p => p.VariazioniProdottis)
                .HasForeignKey(d => d.ProdottoRif)
                .HasConstraintName("FK__Variazion__prodo__49C3F6B7");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
