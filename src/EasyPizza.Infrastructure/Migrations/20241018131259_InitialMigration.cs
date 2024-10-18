using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EasyPizza.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
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
                    PizzaBaseType = table.Column<string>(type: "text", nullable: false),
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
                    PizzaBasePrice = table.Column<decimal>(type: "numeric", nullable: false)
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
                    { new Guid("709b2471-832b-47e1-aaa4-0654bb521244"), false, "Green Pepper", 0.25m },
                    { new Guid("9f103837-663d-4bbf-a3e3-2757bed3a4d0"), false, "Salami", 2.0m },
                    { new Guid("ed93beca-7bbd-4012-a059-b54c581475af"), false, "Cheese", 1.25m }
                });

            migrationBuilder.InsertData(
                table: "PizzaBases",
                columns: new[] { "Id", "Deleted", "PizzaBaseSize", "PizzaBaseType", "Price" },
                values: new object[,]
                {
                    { new Guid("18a10a5e-a74a-4d3c-9a97-f93758edc13d"), false, "Small", "Thin", 1.0m },
                    { new Guid("497b259e-a129-4869-a80c-4139621eb5a8"), false, "Large", "GlutenFree", 1.5m },
                    { new Guid("5e4f389a-b58e-416a-ac4e-17738835d1a6"), false, "Medium", "Thin", 1.2m },
                    { new Guid("695aebd2-e1e6-488a-a569-08e102380755"), false, "Large", "Thin", 1.5m },
                    { new Guid("8a9ecec1-947f-451a-ac9c-94cc57fd1070"), false, "Medium", "GlutenFree", 1.2m },
                    { new Guid("f20ced20-1c6f-47e0-903f-506c2b74ace0"), false, "Small", "GlutenFree", 1.0m }
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
