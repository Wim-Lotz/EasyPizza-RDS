using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EasyPizza.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Total = table.Column<decimal>(type: "numeric", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OrderNumber = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PizzaBases",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    PizzaBaseSize = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaBases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PizzaBaseId = table.Column<Guid>(type: "uuid", nullable: false),
                    PizzaBasePrice = table.Column<decimal>(type: "numeric", nullable: false),
                    PizzaBaseName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pizzas_PizzaBases_PizzaBaseId",
                        column: x => x.PizzaBaseId,
                        principalTable: "PizzaBases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderLines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    PizzaId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderLines_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderLines_Pizzas_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizzas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PizzaIngredients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IngredientPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    IngredientId = table.Column<Guid>(type: "uuid", nullable: false),
                    IngredientName = table.Column<string>(type: "text", nullable: false),
                    PizzaId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaIngredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PizzaIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PizzaIngredients_Pizzas_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizzas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Deleted", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("759fb27c-5762-44b5-8637-1209f0178b23"), false, "cheese", 1.25m },
                    { new Guid("e5182573-18c7-4f23-bbec-e9e486726f42"), false, "green pepper", 0.25m },
                    { new Guid("f638c1af-f4da-4f24-9ac1-f62d79673751"), false, "salami", 2.0m }
                });

            migrationBuilder.InsertData(
                table: "PizzaBases",
                columns: new[] { "Id", "Deleted", "Name", "PizzaBaseSize", "Price" },
                values: new object[,]
                {
                    { new Guid("2aa670fa-5507-440d-ab0a-333eb765215a"), false, "thin crust", "Large", 1.5m },
                    { new Guid("377f0f28-1b9b-407c-9e16-eb34bb6df709"), false, "gluten free", "Large", 1.5m },
                    { new Guid("41196d7a-2bd5-4ca3-bcf1-a5ece88ea77d"), false, "thin crust", "Small", 1.0m },
                    { new Guid("a2db5655-7f72-4900-9ae4-574abb8b66aa"), false, "gluten free", "Small", 1.0m },
                    { new Guid("da008eda-05ee-4550-bc5a-4e00e55c7a18"), false, "gluten free", "Medium", 1.2m },
                    { new Guid("eb42f67e-b03b-416d-b595-f85b6e900bfe"), false, "thin crust", "Medium", 1.2m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_OrderId",
                table: "OrderLines",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_PizzaId",
                table: "OrderLines",
                column: "PizzaId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaIngredients_IngredientId",
                table: "PizzaIngredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaIngredients_PizzaId",
                table: "PizzaIngredients",
                column: "PizzaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_PizzaBaseId",
                table: "Pizzas",
                column: "PizzaBaseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderLines");

            migrationBuilder.DropTable(
                name: "PizzaIngredients");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Pizzas");

            migrationBuilder.DropTable(
                name: "PizzaBases");
        }
    }
}
