using Microsoft.EntityFrameworkCore;

using Wake.Products.Domain.Entities;

namespace Wake.Products.Data;
public sealed class WakeProductsContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured) return;

        optionsBuilder.UseInMemoryDatabase("testewakedb");
    }

    /// <summary>
    /// Aplica os mappings que herdam da IEntityTypeConfiguration automaticamente
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(WakeProductsContext).Assembly);
    }

    /// <summary>
    /// Adiciona data de criação e/ou de atualização na entidade, no momento da persistência no banco de dados
    /// </summary>
    public override int SaveChanges()
    {
        AddTimestamps();
        return base.SaveChanges();
    }

    /// <summary>
    /// Adiciona data de criação e/ou de atualização na entidade, no momento da persistência no banco de dados
    /// </summary>
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        AddTimestamps();
        return base.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// Adiciona data de criação e/ou de atualização na entidade
    /// </summary>
    private void AddTimestamps()
    {
        var entities = ChangeTracker.Entries()
            .Where(x => x.Entity is BaseEntity &&
                (x.State == EntityState.Added ||
                    x.State == EntityState.Modified));

        foreach (var entity in entities)
        {
            var now = DateTime.Now;

            if (entity.State == EntityState.Added)
            {
                ((BaseEntity)entity.Entity).RegisterCreation();
            }

            ((BaseEntity)entity.Entity).RegisterUpdate();
        }
    }
}
