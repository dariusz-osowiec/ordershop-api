using Microsoft.EntityFrameworkCore;
using OrderShopApi.Entities;
using System.Collections.Generic;

namespace OrderShopApi;

public class SQLiteContext : DbContext
{
    /// 
    /// Lista tabel w bazie.
    /// 
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<UserEntity> Users { get; set; }

    /// <summary>
    /// Opisanie encji w bazie danych za pomocą FluentApi.
    /// </summary>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        ///
        /// Opis encji kategorii.
        ///
        builder.Entity<CategoryEntity>(entity =>
        {
            entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("integer")
                .HasAnnotation("Sqlite:Autoincrement", true)
                .ValueGeneratedOnAdd();
            entity.Property(e => e.Name)
                .HasColumnName("name")
                .HasColumnType("text")
                .HasMaxLength(100);
        });
        builder.Entity<CategoryEntity>().HasKey(e => e.Id);

        ///
        /// Opis encji produktu.
        ///
        builder.Entity<ProductEntity>(entity =>
        {
            entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("integer")
                .HasAnnotation("Sqlite:Autoincrement", true)
                .ValueGeneratedOnAdd();
            entity.Property(e => e.Name)
                .HasColumnName("name")
                .HasColumnType("text")
                .HasMaxLength(100);
            entity.Property(e => e.CategoryId)
                .HasColumnName("id_category")
                .HasColumnType("integer");
            entity.Property(e => e.Price)
                .HasColumnName("price")
                .HasColumnType("real");
            entity.Property(e => e.ImageUrl)
                .HasColumnName("image_url")
                .HasColumnType("text");    
        });
        builder.Entity<ProductEntity>().HasKey(e => e.Id);
        builder.Entity<ProductEntity>()
            .HasOne(e => e.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(e => e.CategoryId);

        ///
        /// Opis encji użytkownika.
        ///
        builder.Entity<UserEntity>(entity =>
        {
            entity.Property(e => e.Id)
            .HasColumnName("id")
            .HasColumnType("integer")
            .HasAnnotation("Sqlite:Autoincrement", true)
            .ValueGeneratedOnAdd();
            entity.Property(e => e.Name)
            .HasColumnName("name")
            .HasColumnType("text");
            entity.Property(e => e.Surname)
            .HasColumnName("surname")
            .HasColumnType("text");
            entity.Property(e => e.Email)
            .HasColumnName("email")
            .HasColumnType("text");
            entity.Property(e => e.Password)
            .HasColumnName("password")
            .HasColumnType("text");
            entity.Property(e => e.Address)
            .HasColumnName("addresss")
            .HasColumnType("text");
            entity.Property(e => e.PostCode)
            .HasColumnName("postcode")
            .HasColumnType("text");
            entity.Property(e => e.City)
            .HasColumnName("city")
            .HasColumnType("text");
        });
        builder.Entity<UserEntity>().HasKey(e => e.Id);

        ///
        /// Opis encji płatności.
        ///

    }

    /// <summary>
    /// Konfiguracja połączenia.
    /// </summary>
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder
            .UseLazyLoadingProxies()
            .UseSqlite("Data Source=ordershop.db");
    }
}
