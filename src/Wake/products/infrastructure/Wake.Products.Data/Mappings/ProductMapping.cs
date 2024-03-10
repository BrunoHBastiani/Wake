using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Wake.Products.Domain.Entities;

namespace Wake.Products.Data.Mappings;
public sealed class ProductMapping : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("products");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).HasColumnName("name").IsRequired();
        builder.Property(x => x.Description).HasColumnName("description").IsRequired();
        builder.Property(x => x.Price).HasColumnName("price").IsRequired();
        builder.Property(x => x.Quantity).HasColumnName("quantity").IsRequired();
        builder.Property(x => x.IsActive).HasColumnName("is_active").IsRequired();
        builder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired().HasDefaultValueSql("CURRENT_TIMESTAMP");
        builder.Property(x => x.UpdatedAt).HasColumnName("updated_at").IsRequired().HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasData(
            new Product("Televisão Smart 4K", "Televisão inteligente de alta definição 4K, com acesso a aplicativos de streaming", 1999.99m, 2),
            new Product("Notebook Dell Inspiron 15", "Notebook de última geração com processador Intel Core i7, 16GB de RAM e SSD de 512GB", 3499.99m, 4),
            new Product("Smartphone Samsung Galaxy S21", "Smartphone premium com câmera de alta resolução, tela AMOLED de 6.2 polegadas e 128GB de armazenamento", 2999.99m, 1),
            new Product("Forno Elétrico Philco 45L", "Forno elétrico com capacidade para 45 litros, timer programável e função dourar", 349.99m, 6),
            new Product("Cafeteira Expresso Arno", "Cafeteira automática que prepara café expresso cremoso com apenas um toque", 179.99m, 4));
    }
}
