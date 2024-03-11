using System.ComponentModel.DataAnnotations;

namespace Wake.Products.Domain.Enums;
public enum ProductFieldsEnum
{
    [Display(Name = "Name")]
    Name = 1,
    Description = 2,
    Quantity = 3,
    Price = 4,
    IsActive = 5,
    CreatedAt = 6,
    UpdatedAt = 7,
}
