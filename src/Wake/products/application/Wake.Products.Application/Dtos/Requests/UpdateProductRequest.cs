﻿namespace Wake.Products.Application.Dtos.Requests;
public sealed record UpdateProductRequest
{
    public string? Name { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public decimal? Price { get; set; }
}
