using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Diakok051.Models
{
    public partial class DiakokContext : DbContext
    {
        public DiakokContext()
        {
        }

        public DiakokContext(DbContextOptions<DiakokContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Diak> Diak { get; set; }
        public virtual DbSet<Osztaly> Osztaly { get; set; }
        public virtual DbSet<Tanar> Tanar { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-M6UKM0B\\MSSQL;Database=Diakok;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Hungarian_CI_AS");

            modelBuilder.Entity<Diak>(entity =>
            {
                entity.Property(e => e.DiakID).ValueGeneratedOnAdd();

                entity.Property(e => e.DiakNev).IsUnicode(false);

                entity.HasOne(d => d.Osztaly)
                    .WithMany(p => p.Diak)
                    .HasForeignKey(d => d.OsztalyID)
                    .HasConstraintName("FK__Diak__OsztalyID__2C3393D0");
            });

            modelBuilder.Entity<Osztaly>(entity =>
            {
                entity.Property(e => e.OsztalyID).ValueGeneratedOnAdd();

                entity.Property(e => e.OsztalyJeloles).IsUnicode(false);

                entity.HasOne(d => d.Tanar)
                    .WithMany(p => p.Osztaly)
                    .HasForeignKey(d => d.TanarID)
                    .HasConstraintName("FK__Osztaly__TanarID__286302EC");
            });

            modelBuilder.Entity<Tanar>(entity =>
            {
                entity.Property(e => e.TanarID).ValueGeneratedOnAdd();

                entity.Property(e => e.OktatottTargy).IsUnicode(false);

                entity.Property(e => e.TanarNev).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
