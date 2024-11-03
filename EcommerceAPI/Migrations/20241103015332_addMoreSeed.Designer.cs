﻿// <auto-generated />
using System;
using EcommerceAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace EcommerceAPI.Migrations
{
    [DbContext(typeof(EcommerceContext))]
    [Migration("20241103015332_addMoreSeed")]
    partial class addMoreSeed
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EcommerceAPI.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("NUMBER(18,2)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<int>("UserId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("EcommerceAPI.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("OrderId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("ProductId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("Quantity")
                        .HasColumnType("NUMBER(10)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("NUMBER(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("EcommerceAPI.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<decimal>("Price")
                        .HasColumnType("NUMBER(18,2)");

                    b.Property<int>("StockQuantity")
                        .HasColumnType("NUMBER(10)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TIMESTAMP(7)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = "Categoria A",
                            CreatedAt = new DateTime(2024, 11, 3, 1, 53, 32, 56, DateTimeKind.Utc).AddTicks(5200),
                            Description = "Descrição do Produto A",
                            ImageUrl = "https://example.com/image1.jpg",
                            Name = "Produto A",
                            Price = 10.0m,
                            StockQuantity = 100,
                            UpdatedAt = new DateTime(2024, 11, 3, 1, 53, 32, 56, DateTimeKind.Utc).AddTicks(5200)
                        },
                        new
                        {
                            Id = 2,
                            Category = "Categoria B",
                            CreatedAt = new DateTime(2024, 11, 3, 1, 53, 32, 56, DateTimeKind.Utc).AddTicks(5210),
                            Description = "Descrição do Produto B",
                            ImageUrl = "https://example.com/image2.jpg",
                            Name = "Produto B",
                            Price = 20.0m,
                            StockQuantity = 50,
                            UpdatedAt = new DateTime(2024, 11, 3, 1, 53, 32, 56, DateTimeKind.Utc).AddTicks(5210)
                        },
                        new
                        {
                            Id = 3,
                            Category = "Categoria C",
                            CreatedAt = new DateTime(2024, 11, 3, 1, 53, 32, 56, DateTimeKind.Utc).AddTicks(5210),
                            Description = "Descrição do Produto C",
                            ImageUrl = "https://example.com/image3.jpg",
                            Name = "Produto C",
                            Price = 30.0m,
                            StockQuantity = 75,
                            UpdatedAt = new DateTime(2024, 11, 3, 1, 53, 32, 56, DateTimeKind.Utc).AddTicks(5210)
                        });
                });

            modelBuilder.Entity("EcommerceAPI.Models.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ProductId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<float>("RatingValue")
                        .HasColumnType("BINARY_FLOAT");

                    b.Property<int>("UserId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Ratings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ProductId = 1,
                            RatingValue = 5f,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            ProductId = 2,
                            RatingValue = 4f,
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            ProductId = 2,
                            RatingValue = 5f,
                            UserId = 2
                        },
                        new
                        {
                            Id = 4,
                            ProductId = 3,
                            RatingValue = 3f,
                            UserId = 2
                        });
                });

            modelBuilder.Entity("EcommerceAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("IsActive")
                        .HasColumnType("NUMBER(1)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Role")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TIMESTAMP(7)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 11, 3, 1, 53, 32, 56, DateTimeKind.Utc).AddTicks(4820),
                            Email = "alice@example.com",
                            FirstName = "Alice",
                            IsActive = 1,
                            LastName = "Smith",
                            PasswordHash = "hashedpassword1",
                            Role = "Customer",
                            UpdatedAt = new DateTime(2024, 11, 3, 1, 53, 32, 56, DateTimeKind.Utc).AddTicks(4820)
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 11, 3, 1, 53, 32, 56, DateTimeKind.Utc).AddTicks(4820),
                            Email = "bob@example.com",
                            FirstName = "Bob",
                            IsActive = 1,
                            LastName = "Johnson",
                            PasswordHash = "hashedpassword2",
                            Role = "Admin",
                            UpdatedAt = new DateTime(2024, 11, 3, 1, 53, 32, 56, DateTimeKind.Utc).AddTicks(4820)
                        });
                });

            modelBuilder.Entity("EcommerceAPI.Models.Order", b =>
                {
                    b.HasOne("EcommerceAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("EcommerceAPI.Models.OrderItem", b =>
                {
                    b.HasOne("EcommerceAPI.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EcommerceAPI.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("EcommerceAPI.Models.Rating", b =>
                {
                    b.HasOne("EcommerceAPI.Models.Product", "Product")
                        .WithMany("Ratings")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EcommerceAPI.Models.User", "User")
                        .WithMany("Ratings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EcommerceAPI.Models.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("EcommerceAPI.Models.Product", b =>
                {
                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("EcommerceAPI.Models.User", b =>
                {
                    b.Navigation("Ratings");
                });
#pragma warning restore 612, 618
        }
    }
}
