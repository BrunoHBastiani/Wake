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
                    quantity = table.Column<int>(type: "integer", nullable: false),
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
                columns: new[] { "Id", "created_at", "description", "is_active", "name", "price", "quantity", "updated_at" },
                values: new object[,]
                {
                    { new Guid("2189e256-efbc-4ba4-a92a-76e8f4bea5dd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smartphone premium com câmera de alta resolução, tela AMOLED de 6.2 polegadas e 128GB de armazenamento", true, "Smartphone Samsung Galaxy S21", 2999.99m, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3c197895-c7a9-4e06-9ef6-71b2ba71a961"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Forno elétrico com capacidade para 45 litros, timer programável e função dourar", true, "Forno Elétrico Philco 45L", 349.99m, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("504391c6-c05f-4486-9f71-c7179388924b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Televisão inteligente de alta definição 4K, com acesso a aplicativos de streaming", true, "Televisão Smart 4K", 1999.99m, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("856d2dc9-a93f-4b59-83d3-8b28cc88b9fe"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cafeteira automática que prepara café expresso cremoso com apenas um toque", true, "Cafeteira Expresso Arno", 179.99m, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d0647a40-0e34-4964-afad-49a8e5e4cd0a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Notebook de última geração com processador Intel Core i7, 16GB de RAM e SSD de 512GB", true, "Notebook Dell Inspiron 15", 3499.99m, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
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
