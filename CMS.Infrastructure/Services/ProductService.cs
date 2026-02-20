using CMS.Application.DTOs;
using CMS.Application.Interfaces;
using CMS.Application.Mappers;

namespace CMS.Infrastructure.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ProductResponseDto>> GetAllAsync()
    {
        var products = await _repository.GetAllAsync();
        return products.Select(p => p.ToDto());
    }

    public async Task<ProductResponseDto?> GetByIdAsync(Guid id)
    {
        var product = await _repository.GetByIdAsync(id);
        return product?.ToDto();
    }

    public async Task<ProductResponseDto> CreateAsync(ProductCreateDto dto)
    {
        var product = dto.ToEntity();

        await _repository.AddAsync(product);

        return product.ToDto();
    }

    public async Task<bool> UpdateAsync(Guid id, ProductUpdateDto dto)
    {
        var product = await _repository.GetByIdAsync(id);

        if (product == null)
            return false;

        product.UpdateEntity(dto);

        await _repository.UpdateAsync(product);

        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var product = await _repository.GetByIdAsync(id);

        if (product == null)
            return false;

        // soft delete
        product.IsActive = false; 

        await _repository.UpdateAsync(product);

        return true;
    }
}