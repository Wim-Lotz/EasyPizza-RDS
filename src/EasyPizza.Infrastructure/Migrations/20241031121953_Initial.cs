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
                    PizzaBasePrice = table.Column<decimal>(type: "numeric", nullable: false),
                    PizzaBaseId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pizzas_PizzaBases_PizzaBaseId",
                        column: x => x.PizzaBaseId,
                        principalTable: "PizzaBases",
                        principalColumn: "Id");
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
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderLines_Pizzas_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizzas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PizzaIngredients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IngredientPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    IngredientId = table.Column<Guid>(type: "uuid", nullable: false),
                    PizzaId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaIngredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PizzaIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PizzaIngredients_Pizzas_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizzas",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Deleted", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("16af5c15-3814-4590-a385-897ad7919556"), false, "cheese", 1.25m },
                    { new Guid("76ad2763-e715-4125-8087-03be7eb00552"), false, "salami", 2.0m },
                    { new Guid("b3165107-8c02-44ea-86f2-3c31bbe2be5d"), false, "green pepper", 0.25m }
                });

            migrationBuilder.InsertData(
                table: "PizzaBases",
                columns: new[] { "Id", "Deleted", "Name", "PizzaBaseSize", "Price" },
                values: new object[,]
                {
                    { new Guid("0434c226-a2d5-4d2b-9d62-e969a7c62c08"), false, "thin crust", "Small", 1.0m },
                    { new Guid("325f0ea3-ce42-4aec-b0a2-a5d3a43905dc"), false, "gluten free", "Medium", 1.2m },
                    { new Guid("4fb86e90-3690-4060-b2dc-dcd0ae7d0ffd"), false, "thin crust", "Medium", 1.2m },
                    { new Guid("83f1f205-4c01-4341-92fd-d5e17cf8a1ae"), false, "thin crust", "Large", 1.5m },
                    { new Guid("e03ccc73-8aa5-4c6a-8783-9466e1362235"), false, "gluten free", "Small", 1.0m },
                    { new Guid("e0d62c31-de37-4e82-a898-baca4980b593"), false, "gluten free", "Large", 1.5m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_OrderId",
                table: "OrderLines",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_PizzaId",
                table: "OrderLines",
                column: "PizzaId",
                unique: true);

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
