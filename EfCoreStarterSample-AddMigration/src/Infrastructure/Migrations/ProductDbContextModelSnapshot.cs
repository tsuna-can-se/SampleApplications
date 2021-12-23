﻿// <auto-generated />
using System;
using Infrastructure.Ef;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ProductDbContext))]
    partial class ProductDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "6.0.0-preview.5.21301.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ApplicationCore.Entity.Product", b =>
                {
                    b.Property<long>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,0)");

                    b.Property<long>("ProcuctCategoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("ProductDescription")
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("Name");

                    b.Property<string>("Publisher")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("ProductId");

                    b.HasIndex("ProcuctCategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1L,
                            Price = 2000m,
                            ProcuctCategoryId = 1L,
                            ProductName = "C#の本",
                            Publisher = "DOTNET"
                        },
                        new
                        {
                            ProductId = 2L,
                            Price = 2200m,
                            ProcuctCategoryId = 1L,
                            ProductName = "Visual Studioの本",
                            Publisher = "DOTNET"
                        },
                        new
                        {
                            ProductId = 3L,
                            Price = 2500m,
                            ProcuctCategoryId = 1L,
                            ProductName = ".NETの本",
                            Publisher = "DOTNET"
                        },
                        new
                        {
                            ProductId = 4L,
                            Price = 150000m,
                            ProcuctCategoryId = 2L,
                            ProductName = "冷蔵庫",
                            Publisher = "HUTABISHI"
                        },
                        new
                        {
                            ProductId = 5L,
                            Price = 280m,
                            ProcuctCategoryId = 3L,
                            ProductName = "トランプ",
                            Publisher = "HONTENDO"
                        });
                });

            modelBuilder.Entity("ApplicationCore.Entity.ProductCategory", b =>
                {
                    b.Property<long>("ProductCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("ProductCategoryId");

                    b.ToTable("ProductCategories");

                    b.HasData(
                        new
                        {
                            ProductCategoryId = 1L,
                            Name = "本"
                        },
                        new
                        {
                            ProductCategoryId = 2L,
                            Name = "家電"
                        },
                        new
                        {
                            ProductCategoryId = 3L,
                            Name = "おもちゃ"
                        });
                });

            modelBuilder.Entity("ApplicationCore.Entity.Product", b =>
                {
                    b.HasOne("ApplicationCore.Entity.ProductCategory", "ProductCategory")
                        .WithMany("Products")
                        .HasForeignKey("ProcuctCategoryId")
                        .HasConstraintName("FK_Products_ProductCategories")
                        .IsRequired();

                    b.Navigation("ProductCategory");
                });

            modelBuilder.Entity("ApplicationCore.Entity.ProductCategory", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}