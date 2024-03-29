﻿namespace Wake.Products.Domain.Entities;
public class BaseEntity
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    public void RegisterCreation()
    {
        CreatedAt = DateTime.UtcNow;
    }

    public void RegisterUpdate()
    {
        UpdatedAt = DateTime.UtcNow;
    }
}
