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
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "Id", "description", "is_active", "name", "price", "quantity" },
                values: new object[,]
                {
                    { new Guid("0fdf27c7-2068-4645-a803-a1211a60ee34"), "Cafeteira automática que prepara café expresso cremoso com apenas um toque", true, "Cafeteira Expresso Arno", 179.99m, 4 },
                    { new Guid("660c862e-96bb-43a9-a1ed-1485a071868a"), "Televisão inteligente de alta definição 4K, com acesso a aplicativos de streaming", true, "Televisão Smart 4K", 1999.99m, 2 },
                    { new Guid("e09ed81c-9e1c-4597-84d0-602f7b17cd7c"), "Forno elétrico com capacidade para 45 litros, timer programável e função dourar", true, "Forno Elétrico Philco 45L", 349.99m, 6 },
                    { new Guid("e1a2e648-7c55-4bdd-833d-6a6bbc054843"), "Smartphone premium com câmera de alta resolução, tela AMOLED de 6.2 polegadas e 128GB de armazenamento", true, "Smartphone Samsung Galaxy S21", 2999.99m, 1 },
                    { new Guid("f7b5972d-0369-4a48-b672-859e18e155c2"), "Notebook de última geração com processador Intel Core i7, 16GB de RAM e SSD de 512GB", true, "Notebook Dell Inspiron 15", 3499.99m, 4 }
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
