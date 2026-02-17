using CMS.Application.Interfaces;
using CMS.Domain.Entities;
using CMS.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CMS.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(Guid id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task AddAsync(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
    }

    //  Nota: Metodo agregado 16/02/2026
    public async Task UpdateAsync(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }

    // Nota: Metodo agregado 17/02/2026
    public async Task DeleteAsync(Guid id)
    {
        var product = await _context.Products.FindAsync(id);

        if (product != null)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }


}
