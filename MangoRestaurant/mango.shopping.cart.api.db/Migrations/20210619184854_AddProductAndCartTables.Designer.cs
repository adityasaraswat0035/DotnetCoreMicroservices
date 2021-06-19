﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using mango.shopping.cart.repository.DbContexts;

namespace mango.shopping.cart.api.db.Migrations
{
    [DbContext(typeof(ShoppingCartDbContext))]
    [Migration("20210619184854_AddProductAndCartTables")]
    partial class AddProductAndCartTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("mango.shopping.cart.repository.Entities.CartDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CartHeaderId")
                        .HasColumnType("int")
                        .HasColumnName("CartHeaderId");

                    b.Property<int>("Count")
                        .HasColumnType("int")
                        .HasColumnName("ItemQuantity");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CartHeaderId");

                    b.HasIndex("ProductId")
                        .IsUnique()
                        .HasFilter("[ProductId] IS NOT NULL");

                    b.ToTable("CartDetail");
                });

            modelBuilder.Entity("mango.shopping.cart.repository.Entities.CartHeader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CouponCode")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CouponCode");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.ToTable("CartHeader");
                });

            modelBuilder.Entity("mango.shopping.cart.repository.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("CategoryId");

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CategoryName");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Description");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ImageUrl");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<double>("Price")
                        .HasColumnType("float")
                        .HasColumnName("Price");

                    b.HasKey("Id");

                    b.ToTable("Product", "dbo");
                });

            modelBuilder.Entity("mango.shopping.cart.repository.Entities.CartDetail", b =>
                {
                    b.HasOne("mango.shopping.cart.repository.Entities.CartHeader", "CartHeader")
                        .WithMany("CartDetail")
                        .HasForeignKey("CartHeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("mango.shopping.cart.repository.Entities.Product", "Product")
                        .WithOne()
                        .HasForeignKey("mango.shopping.cart.repository.Entities.CartDetail", "ProductId");

                    b.Navigation("CartHeader");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("mango.shopping.cart.repository.Entities.CartHeader", b =>
                {
                    b.Navigation("CartDetail");
                });
#pragma warning restore 612, 618
        }
    }
}
