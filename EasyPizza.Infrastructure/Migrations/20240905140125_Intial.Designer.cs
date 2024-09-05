﻿// <auto-generated />
using System;
using EasyPizza.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EasyPizza.Infrastructure.Migrations
{
    [DbContext(typeof(EasyPizzaDbContext))]
    [Migration("20240905140125_Intial")]
    partial class Intial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("createdDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("name");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("price");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updatedDate");

                    b.HasKey("Id");

                    b.ToTable("ingredients", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("59a20209-41f6-425d-9825-a2bcd6fb7b86"),
                            CreatedDate = new DateTime(2024, 9, 5, 14, 1, 25, 577, DateTimeKind.Utc).AddTicks(4166),
                            Name = "cheese",
                            Price = 1m,
                            UpdatedDate = new DateTime(2024, 9, 5, 14, 1, 25, 577, DateTimeKind.Utc).AddTicks(4168)
                        },
                        new
                        {
                            Id = new Guid("f67f8c6f-bdd9-48b1-ac18-8fe4f18bd79d"),
                            CreatedDate = new DateTime(2024, 9, 5, 14, 1, 25, 577, DateTimeKind.Utc).AddTicks(4175),
                            Name = "salami",
                            Price = 1.5m,
                            UpdatedDate = new DateTime(2024, 9, 5, 14, 1, 25, 577, DateTimeKind.Utc).AddTicks(4175)
                        },
                        new
                        {
                            Id = new Guid("d3b8bedc-4489-4543-851b-61cc6e000701"),
                            CreatedDate = new DateTime(2024, 9, 5, 14, 1, 25, 577, DateTimeKind.Utc).AddTicks(4179),
                            Name = "green pepper",
                            Price = 1.2m,
                            UpdatedDate = new DateTime(2024, 9, 5, 14, 1, 25, 577, DateTimeKind.Utc).AddTicks(4179)
                        });
                });

            modelBuilder.Entity("EasyPizza.Domain.Entities.Pizza", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("createdDate");

                    b.Property<Guid>("PizzaBaseId")
                        .HasColumnType("uuid")
                        .HasColumnName("pizzaBaseId");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updatedDate");

                    b.HasKey("Id");

                    b.ToTable("pizzas", (string)null);
                });

            modelBuilder.Entity("EasyPizza.Domain.Entities.PizzaBase", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("createdDate");

                    b.Property<string>("PizzaBaseSize")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("size");

                    b.Property<string>("PizzaBaseType")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("type");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("price");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updatedDate");

                    b.HasKey("Id");

                    b.ToTable("pizza_bases", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("778fa88a-9501-4b20-ab8e-5b9212a9a54d"),
                            CreatedDate = new DateTime(2024, 9, 5, 14, 1, 25, 577, DateTimeKind.Utc).AddTicks(4612),
                            PizzaBaseSize = "Small",
                            PizzaBaseType = "GlutenFree",
                            Price = 1m,
                            UpdatedDate = new DateTime(2024, 9, 5, 14, 1, 25, 577, DateTimeKind.Utc).AddTicks(4612)
                        },
                        new
                        {
                            Id = new Guid("a11e9ae4-b24f-4e54-a2ef-d1275f73d373"),
                            CreatedDate = new DateTime(2024, 9, 5, 14, 1, 25, 577, DateTimeKind.Utc).AddTicks(4614),
                            PizzaBaseSize = "Medium",
                            PizzaBaseType = "GlutenFree",
                            Price = 1.2m,
                            UpdatedDate = new DateTime(2024, 9, 5, 14, 1, 25, 577, DateTimeKind.Utc).AddTicks(4614)
                        },
                        new
                        {
                            Id = new Guid("ad7bc2b5-6d50-4235-ade4-1e75466a33b9"),
                            CreatedDate = new DateTime(2024, 9, 5, 14, 1, 25, 577, DateTimeKind.Utc).AddTicks(4615),
                            PizzaBaseSize = "Large",
                            PizzaBaseType = "GlutenFree",
                            Price = 1.5m,
                            UpdatedDate = new DateTime(2024, 9, 5, 14, 1, 25, 577, DateTimeKind.Utc).AddTicks(4616)
                        },
                        new
                        {
                            Id = new Guid("1129fa46-c2df-40ba-b781-e5b72577f794"),
                            CreatedDate = new DateTime(2024, 9, 5, 14, 1, 25, 577, DateTimeKind.Utc).AddTicks(4617),
                            PizzaBaseSize = "Small",
                            PizzaBaseType = "Thin",
                            Price = 1m,
                            UpdatedDate = new DateTime(2024, 9, 5, 14, 1, 25, 577, DateTimeKind.Utc).AddTicks(4617)
                        },
                        new
                        {
                            Id = new Guid("ecbf55cb-ec82-48a8-b580-e34482145018"),
                            CreatedDate = new DateTime(2024, 9, 5, 14, 1, 25, 577, DateTimeKind.Utc).AddTicks(4631),
                            PizzaBaseSize = "Medium",
                            PizzaBaseType = "Thin",
                            Price = 1.2m,
                            UpdatedDate = new DateTime(2024, 9, 5, 14, 1, 25, 577, DateTimeKind.Utc).AddTicks(4631)
                        },
                        new
                        {
                            Id = new Guid("a633b0c3-ca0a-4cc1-aff0-0531f233593b"),
                            CreatedDate = new DateTime(2024, 9, 5, 14, 1, 25, 577, DateTimeKind.Utc).AddTicks(4632),
                            PizzaBaseSize = "Large",
                            PizzaBaseType = "Thin",
                            Price = 1.5m,
                            UpdatedDate = new DateTime(2024, 9, 5, 14, 1, 25, 577, DateTimeKind.Utc).AddTicks(4632)
                        });
                });

            modelBuilder.Entity("EasyPizza.Domain.Entities.PizzaIngredient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("createdDate");

                    b.Property<Guid>("IngredientId")
                        .HasColumnType("uuid")
                        .HasColumnName("ingredientId");

                    b.Property<Guid>("PizzaId")
                        .HasColumnType("uuid")
                        .HasColumnName("pizzaId");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updatedDate");

                    b.HasKey("Id");

                    b.HasIndex("IngredientId");

                    b.HasIndex("PizzaId");

                    b.ToTable("pizza_ingredients", (string)null);
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

            modelBuilder.Entity("EasyPizza.Domain.Entities.Pizza", b =>
                {
                    b.Navigation("PizzaIngredients");
                });
#pragma warning restore 612, 618
        }
    }
}