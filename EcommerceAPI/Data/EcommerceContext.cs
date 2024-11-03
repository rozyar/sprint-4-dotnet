using EcommerceAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace EcommerceAPI.Data
{
    public class EcommerceContext : DbContext
    {
        public EcommerceContext(DbContextOptions<EcommerceContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar a chave primária e estrangeira de Rating
            modelBuilder.Entity<Rating>()
                .HasKey(r => r.Id);

            modelBuilder.Entity<Rating>()
                .HasOne(r => r.User)
                .WithMany(u => u.Ratings)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Rating>()
                .HasOne(r => r.Product)
                .WithMany(p => p.Ratings)
                .HasForeignKey(r => r.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            // Especificar o tipo de coluna para propriedades decimal
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("NUMBER(18,2)");

            modelBuilder.Entity<Order>()
                .Property(o => o.TotalAmount)
                .HasColumnType("NUMBER(18,2)");

            modelBuilder.Entity<OrderItem>()
                .Property(oi => oi.UnitPrice)
                .HasColumnType("NUMBER(18,2)");

            // Mapear boolean como NUMBER(1) porque o Oracle não tem tipo BOOLEAN
            modelBuilder.Entity<User>()
                .Property(u => u.IsActive)
                .HasConversion<int>() // Converte boolean para int
                .HasColumnType("NUMBER(1)");

            // Seed de dados
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FirstName = "Alice",
                    LastName = "Smith",
                    Email = "alice@example.com",
                    PasswordHash = "hashedpassword1",
                    Role = "Customer",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new User
                {
                    Id = 2,
                    FirstName = "Bob",
                    LastName = "Johnson",
                    Email = "bob@example.com",
                    PasswordHash = "hashedpassword2",
                    Role = "Admin",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Produto A",
                    Description = "Descrição do Produto A",
                    Price = 10.0M,
                    StockQuantity = 100,
                    Category = "Categoria A",
                    ImageUrl = "https://example.com/image1.jpg"
                },
                new Product
                {
                    Id = 2,
                    Name = "Produto B",
                    Description = "Descrição do Produto B",
                    Price = 20.0M,
                    StockQuantity = 50,
                    Category = "Categoria B",
                    ImageUrl = "https://example.com/image2.jpg"
                },
                new Product
                {
                    Id = 3,
                    Name = "Produto C",
                    Description = "Descrição do Produto C",
                    Price = 30.0M,
                    StockQuantity = 75,
                    Category = "Categoria C",
                    ImageUrl = "https://example.com/image3.jpg"
                }
            );

            modelBuilder.Entity<Rating>().HasData(
                new Rating { Id = 1, UserId = 1, ProductId = 1, RatingValue = 5.0F },
                new Rating { Id = 2, UserId = 1, ProductId = 2, RatingValue = 4.0F },
                new Rating { Id = 3, UserId = 2, ProductId = 2, RatingValue = 5.0F },
                new Rating { Id = 4, UserId = 2, ProductId = 3, RatingValue = 3.0F }
            );
        }
    }
}
