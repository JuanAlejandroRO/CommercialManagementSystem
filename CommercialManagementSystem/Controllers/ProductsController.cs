using CMS.Application.DTOs;
using CMS.Application.Interfaces;
using CMS.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _repository;

    public ProductsController(IProductRepository repository)
    {
        _repository = repository;
    }

    // GET: api/products
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _repository.GetAllAsync();

        var response = products.Select(p => new ProductResponseDto
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            Stock = p.Stock,
            IsActive = p.IsActive
        });

        return Ok(response);
    }

    // POST: api/products
    [HttpPost]
    public async Task<IActionResult> Create(ProductCreateDto dto)
    {
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Price = dto.Price,
            Stock = dto.Stock,
            IsActive = true
        };

        await _repository.AddAsync(product);

        return Ok(new ProductResponseDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Stock = product.Stock,
            IsActive = product.IsActive
        });
    }

    // PUT: api/products/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, ProductUpdateDto dto)
    {
        var product = await _repository.GetByIdAsync(id);

        if (product == null)
            return NotFound();

        product.Name = dto.Name;
        product.Price = dto.Price;
        product.Stock = dto.Stock;
        product.IsActive = dto.IsActive;

        await _repository.UpdateAsync(product);

        return Ok(new ProductResponseDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Stock = product.Stock,
            IsActive = product.IsActive
        });
    }

    // DELETE: api/products/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var product = await _repository.GetByIdAsync(id);

        if (product == null)
            return NotFound();

        await _repository.DeleteAsync(id);

        return NoContent();
    }

    // Comprobación de prueba de error para el middleware
    [HttpGet("test-error")]
    public IActionResult TestError()
    {
        throw new Exception("Error de prueba");
    }


}
