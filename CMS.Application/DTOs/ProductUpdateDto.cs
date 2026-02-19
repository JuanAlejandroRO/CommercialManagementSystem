using System.ComponentModel.DataAnnotations;

namespace CMS.Application.DTOs;

public class ProductUpdateDto
{
    [Required(ErrorMessage = "El nombre es obligatorio")]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Range(0.01, 999999)]
    public decimal Price { get; set; }

    [Range(0, 100000)]
    public int Stock { get; set; }

    public bool IsActive { get; set; }
}


