using PedeAI.Domain.Entities;

namespace PedeAI.Domain.Interfaces;

public interface IProductRepository
{
    Task AddAsync(Product product);
    Task<Product> GetByIdAsync(string id);
    Task<IEnumerable<Product>> GetAllAsync();
    Task UpdateAsync(Product product);
    Task DeleteAsync(string id);
    Task DeleteAllAsync();
}
