using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EasyPizza.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Intial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ingredients",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    createdDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingredients", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pizza_bases",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    type = table.Column<string>(type: "text", nullable: false),
                    size = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    createdDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pizza_bases", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pizzas",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    createdDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    pizzaBaseId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pizzas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pizza_ingredients",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    createdDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ingredientId = table.Column<Guid>(type: "uuid", nullable: false),
                    pizzaId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pizza_ingredients", x => x.id);
                    table.ForeignKey(
                        name: "FK_pizza_ingredients_ingredients_ingredientId",
                        column: x => x.ingredientId,
                        principalTable: "ingredients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pizza_ingredients_pizzas_pizzaId",
                        column: x => x.pizzaId,
                        principalTable: "pizzas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ingredients",
                columns: new[] { "id", "createdDate", "name", "price", "updatedDate" },
                values: new object[,]
                {
                    { new Guid("59a20209-41f6-425d-9825-a2bcd6fb7b86"), new DateTime(2024, 9, 5, 14, 1, 25, 577, DateTimeKind.Utc).AddTicks(4166), "cheese", 1m, new DateTime(2024, 9, 5, 14, 1, 25, 577, DateTimeKind.Utc).AddTicks(4168) },
                    { new Guid("d3b8bedc-4489-4543-851b-61cc6e000701"), new DateTime(2024, 9, 5, 14, 1, 25, 577, DateTimeKind.Utc).AddTicks(4179), "green pepper", 1.2m, new DateTime(2024, 9, 5, 14, 1, 25, 577, DateTimeKind.Utc).AddTicks(4179) },
                    { new Guid("f67f8c6f-bdd9-48b1-ac18-8fe4f18bd79d"), new DateTime(2024, 9, 5, 14, 1, 25, 577, DateTimeKind.Utc).AddTicks(4175), "salami", 1.5m, new DateTime(2024, 9, 5, 14, 1, 25, 577, DateTimeKind.Utc).AddTicks(4175) }
                });

            migrationBuilder.InsertData(
                table: "pizza_bases",
                columns: new[] { "id", "createdDate", "size", "type", "price", "updatedDate" },
                values: new object[,]
                {
                    { new Guid("1129fa46-c2df-40ba-b781-e5b72577f794"), new DateTime(2024, 9, 5, 14, 1, 25, 577, DateTimeKind.Utc).AddTicks(4617), "Small", "Thin", 1m, new DateTime(2024, 9, 5, 14, 1, 25, 577, DateTimeKind.Utc).AddTicks(4617) },
                    { new Guid("778fa88a-9501-4b20-ab8e-5b9212a9a54d"), new DateTime(2024, 9, 5, 14, 1, 25, 577, DateTimeKind.Utc).AddTicks(4612), "Small", "GlutenFree", 1m, new DateTime(2024, 9, 5, 14, 1, 25, 577, DateTimeKind.Utc).AddTicks(4612) },
                    { new Guid("a11e9ae4-b24f-4e54-a2ef-d1275f73d373"), new DateTime(2024, 9, 5, 14, 1, 25, 577, DateTimeKind.Utc).AddTicks(4614), "Medium", "GlutenFree", 1.2m, new DateTime(2024, 9, 5, 14, 1, 25, 577, DateTimeKind.Utc).AddTicks(4614) },
                    { new Guid("a633b0c3-ca0a-4cc1-aff0-0531f233593b"), new DateTime(2024, 9, 5, 14, 1, 25, 577, DateTimeKind.Utc).AddTicks(4632), "Large", "Thin", 1.5m, new DateTime(2024, 9, 5, 14, 1, 25, 577, DateTimeKind.Utc).AddTicks(4632) },
                    { new Guid("ad7bc2b5-6d50-4235-ade4-1e75466a33b9"), new DateTime(2024, 9, 5, 14, 1, 25, 577, DateTimeKind.Utc).AddTicks(4615), "Large", "GlutenFree", 1.5m, new DateTime(2024, 9, 5, 14, 1, 25, 577, DateTimeKind.Utc).AddTicks(4616) },
                    { new Guid("ecbf55cb-ec82-48a8-b580-e34482145018"), new DateTime(2024, 9, 5, 14, 1, 25, 577, DateTimeKind.Utc).AddTicks(4631), "Medium", "Thin", 1.2m, new DateTime(2024, 9, 5, 14, 1, 25, 577, DateTimeKind.Utc).AddTicks(4631) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_pizza_ingredients_ingredientId",
                table: "pizza_ingredients",
                column: "ingredientId");

            migrationBuilder.CreateIndex(
                name: "IX_pizza_ingredients_pizzaId",
                table: "pizza_ingredients",
                column: "pizzaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pizza_bases");

            migrationBuilder.DropTable(
                name: "pizza_ingredients");

            migrationBuilder.DropTable(
                name: "ingredients");

            migrationBuilder.DropTable(
                name: "pizzas");
        }
    }
}
