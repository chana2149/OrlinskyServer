using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProjectMain.Models;

public partial class dbcontext : DbContext
{
    public dbcontext()
    {
    }

    public dbcontext(DbContextOptions<dbcontext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cattegory> Cattegories { get; set; }

    public virtual DbSet<Costumer> Costumers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductsMain> ProductsMains { get; set; }

    public virtual DbSet<Snif> Snifs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\ProjectMain\\Dal\\Data\\database.mdf;Integrated Security=True;Connect Timeout=30");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cattegory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC07BFECE0ED");

            entity.Property(e => e.Name).HasMaxLength(20);
        });

        modelBuilder.Entity<Costumer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC077AA92D53");

            entity.ToTable("costumers");

            entity.Property(e => e.Id).HasMaxLength(9);
            entity.Property(e => e.Address)
                .HasMaxLength(20)
                .HasColumnName("address");
            entity.Property(e => e.Name).HasMaxLength(20);
            entity.Property(e => e.Telephone)
                .HasMaxLength(20)
                .HasColumnName("telephone");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.IdOrder).HasName("PK__tmp_ms_x__C38F300952814255");

            entity.ToTable("orders");

            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.IdCostumer).HasMaxLength(9);
            entity.Property(e => e.Totalsum).HasColumnName("totalsum");

            entity.HasOne(d => d.IdCostumerNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdCostumer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__orders__IdCostum__5224328E");

            entity.HasOne(d => d.IdSnifNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdSnif)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__orders__IdSnif__71D1E811");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => new { e.IdOrder, e.IdProductSpecific }).HasName("PK__OrderDet__1DD195BEF98A21A4");

            entity.Property(e => e.IdProductSpecific).HasColumnName("idProductSpecific");
            entity.Property(e => e.Nothing)
                .HasMaxLength(10)
                .HasColumnName("nothing");

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.IdOrder)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderDeta__IdOrd__72C60C4A");

            entity.HasOne(d => d.IdProductSpecificNavigation).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.IdProductSpecific)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderDeta__idPro__68487DD7");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC076D3C6CF1");

            entity.ToTable("product");

            entity.Property(e => e.Details)
                .HasMaxLength(51)
                .HasColumnName("details");
            entity.Property(e => e.Name).HasMaxLength(30);
            entity.Property(e => e.Url)
                .HasMaxLength(20)
                .HasColumnName("url");

            entity.HasOne(d => d.IdCattegoryNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdCattegory)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__product__IdCatte__40F9A68C");
        });

        modelBuilder.Entity<ProductsMain>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC079F379E52");

            entity.ToTable("productsMain");

            entity.Property(e => e.Available).HasColumnName("available");
            entity.Property(e => e.CanBeUsed).HasColumnName("canBeUsed");
            entity.Property(e => e.DayTaken)
                .HasColumnType("date")
                .HasColumnName("day taken");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.ProductsMains)
                .HasForeignKey(d => d.IdProduct)
                .HasConstraintName("FK__productsM__IdPro__19AACF41");

            entity.HasOne(d => d.IdSnifNavigation).WithMany(p => p.ProductsMains)
                .HasForeignKey(d => d.IdSnif)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__productsM__IdSni__6A30C649");

            entity.HasMany(d => d.IdCusts).WithMany(p => p.IdFavorates)
                .UsingEntity<Dictionary<string, object>>(
                    "Favorate",
                    r => r.HasOne<Costumer>().WithMany()
                        .HasForeignKey("IdCust")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Favorates__idCus__51300E55"),
                    l => l.HasOne<ProductsMain>().WithMany()
                        .HasForeignKey("IdFavorate")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Favorates__IdFav__531856C7"),
                    j =>
                    {
                        j.HasKey("IdFavorate", "IdCust").HasName("PK__tmp_ms_x__1D120BD8B376EF65");
                        j.ToTable("Favorates");
                        j.IndexerProperty<string>("IdCust")
                            .HasMaxLength(9)
                            .HasColumnName("idCust");
                    });
        });

        modelBuilder.Entity<Snif>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC07D1355C6E");

            entity.ToTable("snif");

            entity.Property(e => e.Address)
                .HasMaxLength(20)
                .HasColumnName("address");
            entity.Property(e => e.Name).HasMaxLength(20);
            entity.Property(e => e.Telephone)
                .HasMaxLength(20)
                .HasColumnName("telephone");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
