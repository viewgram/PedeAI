using MongoDB.Bson;
using MongoDB.Driver;
using PedeAI.Domain.Entities;
using PedeAI.Domain.Interfaces;

namespace PedeAI.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(
            IMongoClient mongoClient,
            IClientSessionHandle clientSessionHandle) : base(mongoClient, clientSessionHandle, "product")
        {
        }

        public async Task AddAsync(Product product)
        {
            await InsertAsync(product);
        }

        public async Task<Product> GetByIdAsync(string id)
        {
            var filter = Builders<Product>.Filter.Eq(s => s.Id, id);
            return await Collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await Collection.Find(Builders<Product>.Filter.Empty).ToListAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.Id, product.Id);
            await Collection.ReplaceOneAsync(filter, product);
        }

        public async Task DeleteAsync(string id)
        {
            await Collection.DeleteOneAsync(p => p.Id == id);
        }
    }
}