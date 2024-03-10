using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Wake.Products.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "Id", "created_at", "description", "is_active", "name", "price", "updated_at" },
                values: new object[,]
                {
                    { new Guid("2933a0e5-3f9d-4591-a075-482ea27134d0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cafeteira automática que prepara café expresso cremoso com apenas um toque", true, "Cafeteira Expresso Arno", 179.99m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3e22e0ca-a12c-4413-a728-8564ce6e9761"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Notebook de última geração com processador Intel Core i7, 16GB de RAM e SSD de 512GB", true, "Notebook Dell Inspiron 15", 3499.99m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("68efd645-342c-4bc5-80ee-a4c518d327c3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Televisão inteligente de alta definição 4K, com acesso a aplicativos de streaming", true, "Televisão Smart 4K", 1999.99m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a6d807d2-6030-4e02-9708-a0439f34ba5c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Forno elétrico com capacidade para 45 litros, timer programável e função dourar", true, "Forno Elétrico Philco 45L", 349.99m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ff6401dd-7208-4711-bb6e-ef810689f078"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smartphone premium com câmera de alta resolução, tela AMOLED de 6.2 polegadas e 128GB de armazenamento", true, "Smartphone Samsung Galaxy S21", 2999.99m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");
        }
    }
}
