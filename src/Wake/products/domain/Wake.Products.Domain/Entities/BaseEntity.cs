namespace Wake.Products.Domain.Entities;
public class BaseEntity
{
    public Guid Id { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    public void RegisterCreation()
    {
        CreatedAt = DateTime.Now;
    }

    public void RegisterUpdate()
    {
        UpdatedAt = DateTime.Now;
    }

    public BaseEntity()
    {
        Id = Guid.NewGuid();
    }
}
