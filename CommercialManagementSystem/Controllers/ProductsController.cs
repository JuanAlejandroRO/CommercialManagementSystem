using CMS.Application.Interfaces;
using CMS.Domain.Entities;
using CMS.Infrastructure.Repositories;
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

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _repository.GetAllAsync();
        return Ok(products);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Product product)
    {
        product.Id = Guid.NewGuid();
        await _repository.AddAsync(product);
        return Ok(product);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, Product product)
    {
        var existingProduct = await _repository.GetByIdAsync(id);

        if (existingProduct == null)
            return NotFound();

        existingProduct.Name = product.Name;
        existingProduct.Price = product.Price;
        existingProduct.Stock = product.Stock;
        existingProduct.IsActive = product.IsActive;

        await _repository.UpdateAsync(existingProduct);

        return Ok(existingProduct);
    }
}
