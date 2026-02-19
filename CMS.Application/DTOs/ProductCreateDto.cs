using System.ComponentModel.DataAnnotations;

namespace CMS.Application.DTOs;

public class ProductCreateDto
{
    [Required(ErrorMessage = "El nombre es obligatorio")]
    [MaxLength(100, ErrorMessage = "Máximo 100 caracteres")]
    public string Name { get; set; } = string.Empty;

    [Range(0.01, 999999, ErrorMessage = "El precio debe ser mayor a 0")]
    public decimal Price { get; set; }

    [Range(0, 100000, ErrorMessage = "Stock inválido")]
    public int Stock { get; set; }

    public bool IsActive { get; set; } = true;
}


