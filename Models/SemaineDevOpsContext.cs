using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SemaineDevOps.Models;

public partial class SemaineDevOpsContext : DbContext
{
    public SemaineDevOpsContext()
    {
    }

    public SemaineDevOpsContext(DbContextOptions<SemaineDevOpsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Axe> Axes { get; set; }

    public virtual DbSet<Categorie> Categories { get; set; }

    public virtual DbSet<Entreprise> Entreprises { get; set; }

    public virtual DbSet<Point> Points { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Regrouper> Regroupers { get; set; }

    public virtual DbSet<Reponse> Reponses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=172.16.47.132;Initial Catalog=SemaineDevOps;User ID=sa;Password=YourStrong!Passw0rd;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Axe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Axe__3214EC0713DC2F3E");

            entity.ToTable("Axe");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Nom)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Categorie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC07BEC90B90");

            entity.ToTable("Categorie");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Nom)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Axe).WithMany(p => p.Categories)
                .HasForeignKey(d => d.AxeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Categorie_Axe");
        });

        modelBuilder.Entity<Entreprise>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Entrepri__3214EC07633B90A3");

            entity.ToTable("Entreprise");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Adresse)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Domaine)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Nom)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Ville)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Point>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Point__3214EC073994038D");

            entity.ToTable("Point");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Descriptif).HasColumnType("text");

            entity.HasOne(d => d.Question).WithMany(p => p.Points)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("FK_Point_Question");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Question__3214EC0728EE3932");

            entity.ToTable("Question");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Nom)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Categorie).WithMany(p => p.Questions)
                .HasForeignKey(d => d.CategorieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Question_Categorie");
        });

        modelBuilder.Entity<Regrouper>(entity =>
        {
            entity.ToTable("Regrouper");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Entreprise).WithMany(p => p.Regroupers)
                .HasForeignKey(d => d.EntrepriseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Regrouper_Entreprise");

            entity.HasOne(d => d.Question).WithMany(p => p.Regroupers)
                .HasForeignKey(d => d.QuestionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Regrouper_Question");

            entity.HasOne(d => d.Reponse).WithMany(p => p.Regroupers)
                .HasForeignKey(d => d.ReponseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Regrouper_Reponse");
        });

        modelBuilder.Entity<Reponse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reponse__3214EC07A89D1555");

            entity.ToTable("Reponse");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Commentaire)
                .HasColumnType("text")
                .HasColumnName("commentaire");
            entity.Property(e => e.Score).HasColumnName("score");

            entity.HasOne(d => d.Question).WithMany(p => p.Reponses)
                .HasForeignKey(d => d.QuestionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reponse_Question");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
