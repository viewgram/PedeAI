using MongoDB.Driver;
using PedeAI.Domain.Entities;
using PedeAI.Domain.Interfaces;

namespace PedeAI.Infrastructure.Repositories;

public class OrderRepository : BaseRepository<Order>, IOrderRepository
{
    public OrderRepository(
        IMongoClient mongoClient,
        IClientSessionHandle clientSessionHandle) : base(mongoClient, clientSessionHandle, "order")
    {

    }

    public async Task AddAsync(Order order)
    {
        await InsertAsync(order);
    }

    public async Task<Order> GetByIdAsync(string id)
    {
        var filter = Builders<Order>.Filter.Eq(s => s.Id, id);
        return await Collection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        return await Collection.Find(Builders<Order>.Filter.Empty).ToListAsync();
    }

    public async Task UpdateAsync(Order order)
    {
        var filter = Builders<Order>.Filter.Eq(p => p.Id, order.Id);
        await Collection.ReplaceOneAsync(filter, order);
    }

    public async Task DeleteAsync(string id)
    {
        await Collection.DeleteOneAsync(p => p.Id == id);
    }
}