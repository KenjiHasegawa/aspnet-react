using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GuestCheckApp.Models
{
    public partial class GuestCheckAppKenji_dbContext : DbContext
    {
        public GuestCheckAppKenji_dbContext()
        {
        }

        public GuestCheckAppKenji_dbContext(DbContextOptions<GuestCheckAppKenji_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblGuestCheck> TblGuestCheck { get; set; }
        public virtual DbSet<TblGuestCheckProduct> TblGuestCheckProduct { get; set; }
        public virtual DbSet<TblProduct> TblProduct { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=guestcheckappkenjidbserver.database.windows.net;Initial Catalog=GuestCheckAppKenji_db;User ID=kenjidbserver;Password=asc@453@dfb;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblGuestCheck>(entity =>
            {
                entity.HasKey(e => e.GuestCheckId)
                    .HasName("PK__tblGuest__4E4854116B416188");

                entity.ToTable("tblGuestCheck");

                entity.Property(e => e.GuestCheckId).HasColumnName("GuestCheckID");

                entity.Property(e => e.GuestCheckStatus)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GuestCheckValue)
                    .HasColumnType("decimal(9, 2)")
                    .HasDefaultValueSql("((0.00))");
            });

            modelBuilder.Entity<TblGuestCheckProduct>(entity =>
            {
                entity.HasKey(e => e.GuestCheckProductId)
                    .HasName("PK__tblGuest__9F5E6224E0411B47");

                entity.ToTable("tblGuestCheckProduct");

                entity.Property(e => e.GuestCheckProductId).HasColumnName("GuestCheckProductID");

                entity.Property(e => e.GuestCheckId).HasColumnName("GuestCheckID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");
            });

            modelBuilder.Entity<TblProduct>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__tblProdu__B40CC6EDBA7FA51C");

                entity.ToTable("tblProduct");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductDescription)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProductType)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ProductValue)
                    .HasColumnType("decimal(9, 2)")
                    .HasDefaultValueSql("((0.00))");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
