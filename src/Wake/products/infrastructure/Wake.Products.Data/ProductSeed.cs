using Microsoft.EntityFrameworkCore;

using Wake.Products.Domain.Entities;

namespace Wake.Products.Data
{
    public static class ProductSeed
    {
        public static async Task SeedAsync(WakeProductsContext context)
        {
            if (await context.Products.AnyAsync())
            {
                return;
            }

            var products = new[]
            {
                new Product("Televisão Smart 4K", "Televisão inteligente de alta definição 4K, com acesso a aplicativos de streaming", 1999.99m),
                new Product("Notebook Dell Inspiron 15", "Notebook de última geração com processador Intel Core i7, 16GB de RAM e SSD de 512GB", 3499.99m),
                new Product("Smartphone Samsung Galaxy S21", "Smartphone premium com câmera de alta resolução, tela AMOLED de 6.2 polegadas e 128GB de armazenamento", 2999.99m),
                new Product("Forno Elétrico Philco 45L", "Forno elétrico com capacidade para 45 litros, timer programável e função dourar", 349.99m),
                new Product("Cafeteira Expresso Arno", "Cafeteira automática que prepara café expresso cremoso com apenas um toque", 179.99m)
            };

            await context.Products.AddRangeAsync(products);
            await context.SaveChangesAsync();
        }
    }
}
