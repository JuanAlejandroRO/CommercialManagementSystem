using CMS.Domain.Entities;

namespace CMS.Application.Interfaces;

public interface IProductRepository
{
    Task<List<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(Guid id);
    Task AddAsync(Product product);

    //Agregado 16/02/2026
    Task UpdateAsync(Product product);

}


