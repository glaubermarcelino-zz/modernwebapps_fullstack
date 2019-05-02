﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ModernStore.Infra.Contexts;

namespace ModernStore.Infra.Migrations
{
    [DbContext(typeof(ModernStoreDataContext))]
    [Migration("20190502083303_FirstBase")]
    partial class FirstBase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ModernStore.Domain.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("BirthDate");

                    b.Property<Guid>("CreatedBy");

                    b.Property<DateTime>("CreatedIn");

                    b.Property<string>("DocumentNumber");

                    b.Property<string>("EmailAddress");

                    b.Property<string>("NameLastName");

                    b.Property<Guid>("UpdatedBy");

                    b.Property<DateTime>("UpdatedIn");

                    b.Property<Guid?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("DocumentNumber");

                    b.HasIndex("EmailAddress");

                    b.HasIndex("NameLastName");

                    b.HasIndex("UserId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("ModernStore.Domain.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<Guid>("CreatedBy");

                    b.Property<DateTime>("CreatedIn");

                    b.Property<Guid?>("CustomerId");

                    b.Property<decimal>("DeliveryFee")
                        .HasColumnType("money");

                    b.Property<decimal>("Discount")
                        .HasColumnType("money");

                    b.Property<string>("Number")
                        .IsRequired()
                        .IsFixedLength(true)
                        .HasMaxLength(8);

                    b.Property<int>("Status");

                    b.Property<Guid>("UpdatedBy");

                    b.Property<DateTime>("UpdatedIn");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("ModernStore.Domain.Entities.OrderItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CreatedBy");

                    b.Property<DateTime>("CreatedIn");

                    b.Property<Guid?>("OrderId");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<Guid?>("ProductId");

                    b.Property<int>("Quantity");

                    b.Property<Guid>("UpdatedBy");

                    b.Property<DateTime>("UpdatedIn");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("ModernStore.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CreatedBy");

                    b.Property<DateTime>("CreatedIn");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(1024);

                    b.Property<decimal>("Price");

                    b.Property<int>("QuantityOnHand");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<Guid>("UpdatedBy");

                    b.Property<DateTime>("UpdatedIn");

                    b.HasKey("Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("ModernStore.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<Guid>("CreatedBy");

                    b.Property<DateTime>("CreatedIn");

                    b.Property<string>("Password")
                        .IsRequired()
                        .IsFixedLength(true)
                        .HasMaxLength(32);

                    b.Property<Guid>("UpdatedBy");

                    b.Property<DateTime>("UpdatedIn");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ModernStore.Domain.ValueObjects.Document", b =>
                {
                    b.Property<string>("Number")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Number");

                    b.ToTable("Document");
                });

            modelBuilder.Entity("ModernStore.Domain.ValueObjects.Email", b =>
                {
                    b.Property<string>("EmailAddress")
                        .ValueGeneratedOnAdd();

                    b.HasKey("EmailAddress");

                    b.ToTable("Email");
                });

            modelBuilder.Entity("ModernStore.Domain.ValueObjects.Name", b =>
                {
                    b.Property<string>("LastName")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.HasKey("LastName");

                    b.ToTable("Name");
                });

            modelBuilder.Entity("ModernStore.Domain.Entities.Customer", b =>
                {
                    b.HasOne("ModernStore.Domain.ValueObjects.Document", "Document")
                        .WithMany()
                        .HasForeignKey("DocumentNumber");

                    b.HasOne("ModernStore.Domain.ValueObjects.Email", "Email")
                        .WithMany()
                        .HasForeignKey("EmailAddress");

                    b.HasOne("ModernStore.Domain.ValueObjects.Name", "Name")
                        .WithMany()
                        .HasForeignKey("NameLastName");

                    b.HasOne("ModernStore.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("ModernStore.Domain.Entities.Order", b =>
                {
                    b.HasOne("ModernStore.Domain.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("ModernStore.Domain.Entities.OrderItem", b =>
                {
                    b.HasOne("ModernStore.Domain.Entities.Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId");

                    b.HasOne("ModernStore.Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");
                });
#pragma warning restore 612, 618
        }
    }
}
