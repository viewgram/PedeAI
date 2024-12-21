using PedeAI.Domain.Entities;

namespace PedeAI.Domain.Interfaces;

public interface IOrderRepository
{
    Task AddAsync(Order product);
    Task<Order> GetByIdAsync(string id);
    Task<IEnumerable<Order>> GetAllAsync();
    Task UpdateAsync(Order product);
    Task DeleteAsync(string id);
}