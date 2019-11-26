using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GuestCheckApp.Models
{
    public partial class GuestCheckAppKenji_dbContext : DbContext
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<GuestCheck> GuestCheck { get; set; }
        public DbSet<GuestCheckProduct> GuestCheckProduct { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<GuestCheck> GuestChecks { get; set; }
        public DbSet<GuestCheckProduct> GuestCheckProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=guestcheckappkenjidbserver.database.windows.net;Initial Catalog=GuestCheckAppKenji_db;User ID=kenjidbserver;Password=asc@453@dfb;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ProductID).HasColumnName("ProductID");

                entity.Property(e => e.ProductDescription)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
                modelBuilder.Entity<GuestCheckProduct>().HasKey(gcp => new { gcp.ProductID, gcp.GuestCheckID });

                entity.Property(e => e.ProductType)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
                modelBuilder.Entity<GuestCheckProduct>()
                    .HasOne<Product>(gcp => gcp.Product)
                    .WithMany(p => p.GuestCheckProducts)
                    .HasForeignKey(gcp => gcp.ProductID);

                entity.Property(e => e.ProductValue)
                    .HasColumnType("decimal(9, 2)")
                    .HasDefaultValueSql("((0.00))");
            });

            modelBuilder.Entity<GuestCheck>(entity =>
            {
                entity.ToTable("GuestCheck");

                entity.Property(e => e.GuestCheckID).HasColumnName("GuestCheckID");

                entity.Property(e => e.GuestCheckStatus)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GuestCheckValue)
                    .HasColumnType("decimal(9, 2)")
                    .HasDefaultValueSql("((0.00))");
            });

            modelBuilder.Entity<GuestCheckProduct>(entity =>
            {
                entity.ToTable("GuestCheckProduct");

                entity.HasKey(gcp => new { gcp.ProductID, gcp.GuestCheckID });

                entity.HasOne<Product>(gcp => gcp.Product)
                .WithMany(p => p.GuestCheckProducts)
                .HasForeignKey(gcp => gcp.ProductID);

                entity.HasOne<GuestCheck>(gcp => gcp.GuestCheck)
                .WithMany(gc => gc.GuestCheckProducts)
                .HasForeignKey(gcp => gcp.GuestCheckID);

                entity.Property(e => e.GuestCheckID).HasColumnName("GuestCheckID");

                entity.Property(e => e.ProductID).HasColumnName("ProductID");
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
