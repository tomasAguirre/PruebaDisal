using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PruebaDisal.Models
{
    public partial class DBCONTEXT : DbContext
    {
        public DBCONTEXT()
        {
        }

        public DBCONTEXT(DbContextOptions<DBCONTEXT> options)
            : base(options)
        {
        }

        public virtual DbSet<List> Lists { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductTax> ProductTaxes { get; set; }
        public virtual DbSet<ProductoPrice> ProductoPrices { get; set; }
        public virtual DbSet<Tax> Taxes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-TN9INFF8\\SQLEXPRESS;Initial Catalog=TEST_DEV;Integrated Security=True;ConnectRetryCount=0");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<List>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<ProductTax>(entity =>
            {
                entity.Property(e => e.Type).IsUnicode(false);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductTaxes)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCT_TAX_PRODUCT");

                entity.HasOne(d => d.Tax)
                    .WithMany(p => p.ProductTaxes)
                    .HasForeignKey(d => d.TaxId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCT_TAX_PRODUCT_TAX");
            });

            modelBuilder.Entity<ProductoPrice>(entity =>
            {
                entity.HasOne(d => d.List)
                    .WithMany(p => p.ProductoPrices)
                    .HasForeignKey(d => d.ListId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCTO_PRICE_LIST");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductoPrices)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRI_PRODUCTO_PRICE_PRO_PRODUCT");
            });

            modelBuilder.Entity<Tax>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }


        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
