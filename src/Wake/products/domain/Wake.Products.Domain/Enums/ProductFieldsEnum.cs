using System.ComponentModel.DataAnnotations;

namespace Wake.Products.Domain.Enums;
public enum ProductFieldsEnum
{
    [Display(Name = "Name")]
    Name = 1,
    Description = 2,
    Price = 3,
    IsActive = 4,
    CreatedAt = 5,
    UpdatedAt = 6,
}
