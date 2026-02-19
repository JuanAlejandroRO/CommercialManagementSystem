using CMS.Application.DTOs;
using CMS.Domain.Entities;

namespace CMS.Application.Mappers;

public static class ProductMapper
{
    public static ProductResponseDto ToDto(this Product product)
    {
        return new ProductResponseDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Stock = product.Stock,
            IsActive = product.IsActive
        };
    }

    public static Product ToEntity(this ProductCreateDto dto)
    {
        return new Product
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Price = dto.Price,
            Stock = dto.Stock,
            IsActive = true
        };
    }

    public static void UpdateEntity(this Product product, ProductUpdateDto dto)
    {
        product.Name = dto.Name;
        product.Price = dto.Price;
        product.Stock = dto.Stock;
    }
}

