using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TeachTask.DataDB
{
    public partial class TeachDBContext : DbContext
    {
        public TeachDBContext()
        {
        }

        public TeachDBContext(DbContextOptions<TeachDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DigitalImage> DigitalImages { get; set; } = null!;
        public virtual DbSet<GraphicProduct> GraphicProducts { get; set; } = null!;
        public virtual DbSet<Primary> Primaries { get; set; } = null!;
        public virtual DbSet<PrimarySecondary> PrimarySecondaries { get; set; } = null!;
        public virtual DbSet<Resource> Resources { get; set; } = null!;
        public virtual DbSet<Secondary> Secondaries { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-JAGNJO4;Initial Catalog=TeachDB;Integrated Security=True;Pooling=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DigitalImage>(entity =>
            {
                entity.ToTable("DigitalImage");

                entity.HasOne(d => d.GraphicProduct)
                    .WithMany(p => p.DigitalImages)
                    .HasForeignKey(d => d.GraphicProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DigitalImage_GraphicProduct");

                entity.HasOne(d => d.Resource)
                    .WithMany(p => p.DigitalImages)
                    .HasForeignKey(d => d.ResourceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DigitalImage_Resource");
            });

            modelBuilder.Entity<GraphicProduct>(entity =>
            {
                entity.ToTable("GraphicProduct");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Primary>(entity =>
            {
                entity.ToTable("Primary");

                entity.Property(e => e.Address).HasMaxLength(50);
            });

            modelBuilder.Entity<PrimarySecondary>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("PrimarySecondary");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.NamePhotographer).HasMaxLength(50);
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.ToTable("Resource");

                entity.HasOne(d => d.Primary)
                    .WithMany(p => p.Resources)
                    .HasForeignKey(d => d.PrimaryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Resource_Primary");

                entity.HasOne(d => d.Secondary)
                    .WithMany(p => p.Resources)
                    .HasForeignKey(d => d.SecondaryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Resource_Secondary");
            });

            modelBuilder.Entity<Secondary>(entity =>
            {
                entity.ToTable("Secondary");

                entity.Property(e => e.NamePhotographer).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
