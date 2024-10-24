﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Product.Infrastructure.Data;

#nullable disable

namespace Product.Infrastructure.Data.migrationseed
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241024094808_seedingdata")]
    partial class seedingdata
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Product.Core.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("ProductsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductsId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "描述 1",
                            Name = "類別 1"
                        },
                        new
                        {
                            Id = 2,
                            Description = "描述 2",
                            Name = "類別 2"
                        },
                        new
                        {
                            Id = 3,
                            Description = "描述 3",
                            Name = "類別 3"
                        },
                        new
                        {
                            Id = 4,
                            Description = "描述 4",
                            Name = "類別 4"
                        });
                });

            modelBuilder.Entity("Product.Core.Entities.Products", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "描述 1",
                            Name = "商品 1",
                            Price = 100
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Description = "描述 2",
                            Name = "商品 2",
                            Price = 300
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            Description = "描述 3",
                            Name = "商品 3",
                            Price = 500
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            Description = "描述 4",
                            Name = "商品 4",
                            Price = 900
                        });
                });

            modelBuilder.Entity("Product.Core.Entities.Category", b =>
                {
                    b.HasOne("Product.Core.Entities.Products", null)
                        .WithMany("Category")
                        .HasForeignKey("ProductsId");
                });

            modelBuilder.Entity("Product.Core.Entities.Products", b =>
                {
                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}