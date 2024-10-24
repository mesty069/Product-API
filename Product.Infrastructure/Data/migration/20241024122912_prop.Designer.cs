﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Product.Infrastructure.Data;

#nullable disable

namespace Product.Infrastructure.Data.migration
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241024122912_prop")]
    partial class prop
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

                    b.HasKey("Id");

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

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductPicture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "Description 1",
                            Name = "Product 1",
                            Price = 100m,
                            ProductPicture = "https://"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Description = "Description 2",
                            Name = "Product 2",
                            Price = 300m,
                            ProductPicture = "https://"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            Description = "Description 3",
                            Name = "Product 3",
                            Price = 500m,
                            ProductPicture = "https://"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            Description = "Description 4",
                            Name = "Product 4",
                            Price = 900m,
                            ProductPicture = "https://"
                        });
                });

            modelBuilder.Entity("Product.Core.Entities.Products", b =>
                {
                    b.HasOne("Product.Core.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
