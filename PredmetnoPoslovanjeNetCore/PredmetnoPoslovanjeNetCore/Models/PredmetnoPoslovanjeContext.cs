using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PredmetnoPoslovanjeNetCore.Models
{
    public partial class PredmetnoPoslovanjeContext : DbContext
    {

        public PredmetnoPoslovanjeContext(DbContextOptions<PredmetnoPoslovanjeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Akt> Akt { get; set; }
        public virtual DbSet<ClassPredmetRadnikRelation> ClassPredmetRadnikRelation { get; set; }
        public virtual DbSet<Predmet> Predmet { get; set; }
        public virtual DbSet<Radnik> Radnik { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=PredmetnoPoslovanje;Integrated Security=True;ConnectRetryCount=0");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Akt>(entity =>
            {
                entity.HasKey(e => e.IdAkta)
                    .HasName("PK__Akt__261A3735272C1A85");

                entity.Property(e => e.NazivAkta).IsUnicode(false);

                entity.Property(e => e.Posiljalac).IsUnicode(false);

                entity.HasOne(d => d.IdPredmetaNavigation)
                    .WithMany(p => p.Akt)
                    .HasForeignKey(d => d.IdPredmeta)
                    .HasConstraintName("FK__Akt__IdPredmeta__4316F928");
            });

            modelBuilder.Entity<ClassPredmetRadnikRelation>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => new { e.IdPredmeta, e.IdRadnika })
                    .HasName("UQ__ClassPre__04C9A17C327A03FB")
                    .IsUnique();

                entity.HasOne(d => d.IdPredmetaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdPredmeta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ClassPred__IdPre__47DBAE45");

                entity.HasOne(d => d.IdRadnikaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdRadnika)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ClassPred__IdRad__48CFD27E");
            });

            modelBuilder.Entity<Predmet>(entity =>
            {
                entity.HasKey(e => e.IdPredmeta)
                    .HasName("PK__Predmet__E560301514676A22");

                entity.Property(e => e.NazivPredmeta).IsUnicode(false);

                entity.Property(e => e.VrstaPredmeta).IsUnicode(false);
            });

            modelBuilder.Entity<Radnik>(entity =>
            {
                entity.HasKey(e => e.IdRadnika)
                    .HasName("PK__Radnik__1A99168FE695DD6D");

                entity.Property(e => e.BrojTelefona).IsUnicode(false);

                entity.Property(e => e.ImeIprezime).IsUnicode(false);

                entity.Property(e => e.Pozicija).IsUnicode(false);

                entity.Property(e => e.Sektor).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        
    }
        
}
