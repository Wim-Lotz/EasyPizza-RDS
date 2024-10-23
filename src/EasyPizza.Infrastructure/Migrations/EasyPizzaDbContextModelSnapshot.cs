﻿// <auto-generated />
using System;
using EasyPizza.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EasyPizza.Infrastructure.Migrations
{
    [DbContext(typeof(EasyPizzaDbContext))]
    partial class EasyPizzaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EasyPizza.Domain.Entities.Ingredient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");

                    b.HasData(
                        new
                        {
                            Id = new Guid("759fb27c-5762-44b5-8637-1209f0178b23"),
                            Deleted = false,
                            Name = "cheese",
                            Price = 1.25m
                        },
                        new
                        {
                            Id = new Guid("f638c1af-f4da-4f24-9ac1-f62d79673751"),
                            Deleted = false,
                            Name = "salami",
                            Price = 2.0m
                        },
                        new
                        {
                            Id = new Guid("e5182573-18c7-4f23-bbec-e9e486726f42"),
                            Deleted = false,
                            Name = "green pepper",
                            Price = 0.25m
                        });
                });

            modelBuilder.Entity("EasyPizza.Domain.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("OrderNumber")
                        .HasColumnType("integer");

                    b.Property<decimal>("Total")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("EasyPizza.Domain.Entities.OrderLine", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PizzaId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("PizzaId");

                    b.ToTable("OrderLines");
                });

            modelBuilder.Entity("EasyPizza.Domain.Entities.Pizza", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("PizzaBaseId")
                        .HasColumnType("uuid");

                    b.Property<string>("PizzaBaseName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("PizzaBasePrice")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("PizzaBaseId");

                    b.ToTable("Pizzas");
                });

            modelBuilder.Entity("EasyPizza.Domain.Entities.PizzaBase", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("PizzaBaseSize")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("PizzaBases");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a2db5655-7f72-4900-9ae4-574abb8b66aa"),
                            Deleted = false,
                            Name = "gluten free",
                            PizzaBaseSize = "Small",
                            Price = 1.0m
                        },
                        new
                        {
                            Id = new Guid("da008eda-05ee-4550-bc5a-4e00e55c7a18"),
                            Deleted = false,
                            Name = "gluten free",
                            PizzaBaseSize = "Medium",
                            Price = 1.2m
                        },
                        new
                        {
                            Id = new Guid("377f0f28-1b9b-407c-9e16-eb34bb6df709"),
                            Deleted = false,
                            Name = "gluten free",
                            PizzaBaseSize = "Large",
                            Price = 1.5m
                        },
                        new
                        {
                            Id = new Guid("41196d7a-2bd5-4ca3-bcf1-a5ece88ea77d"),
                            Deleted = false,
                            Name = "thin crust",
                            PizzaBaseSize = "Small",
                            Price = 1.0m
                        },
                        new
                        {
                            Id = new Guid("eb42f67e-b03b-416d-b595-f85b6e900bfe"),
                            Deleted = false,
                            Name = "thin crust",
                            PizzaBaseSize = "Medium",
                            Price = 1.2m
                        },
                        new
                        {
                            Id = new Guid("2aa670fa-5507-440d-ab0a-333eb765215a"),
                            Deleted = false,
                            Name = "thin crust",
                            PizzaBaseSize = "Large",
                            Price = 1.5m
                        });
                });

            modelBuilder.Entity("EasyPizza.Domain.Entities.PizzaIngredient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("IngredientId")
                        .HasColumnType("uuid");

                    b.Property<string>("IngredientName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("IngredientPrice")
                        .HasColumnType("numeric");

                    b.Property<Guid>("PizzaId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("IngredientId");

                    b.HasIndex("PizzaId");

                    b.ToTable("PizzaIngredients");
                });

            modelBuilder.Entity("EasyPizza.Domain.Entities.OrderLine", b =>
                {
                    b.HasOne("EasyPizza.Domain.Entities.Order", null)
                        .WithMany("OrderLines")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EasyPizza.Domain.Entities.Pizza", null)
                        .WithMany("OrderLines")
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EasyPizza.Domain.Entities.Pizza", b =>
                {
                    b.HasOne("EasyPizza.Domain.Entities.PizzaBase", null)
                        .WithMany("Pizzas")
                        .HasForeignKey("PizzaBaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EasyPizza.Domain.Entities.PizzaIngredient", b =>
                {
                    b.HasOne("EasyPizza.Domain.Entities.Ingredient", null)
                        .WithMany("PizzaIngredients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EasyPizza.Domain.Entities.Pizza", null)
                        .WithMany("PizzaIngredients")
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EasyPizza.Domain.Entities.Ingredient", b =>
                {
                    b.Navigation("PizzaIngredients");
                });

            modelBuilder.Entity("EasyPizza.Domain.Entities.Order", b =>
                {
                    b.Navigation("OrderLines");
                });

            modelBuilder.Entity("EasyPizza.Domain.Entities.Pizza", b =>
                {
                    b.Navigation("OrderLines");

                    b.Navigation("PizzaIngredients");
                });

            modelBuilder.Entity("EasyPizza.Domain.Entities.PizzaBase", b =>
                {
                    b.Navigation("Pizzas");
                });
#pragma warning restore 612, 618
        }
    }
}
