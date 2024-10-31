using MongoDB.Driver;
using PedeAI.Domain.Entities;
using PedeAI.Domain.Interfaces;
using PedeAI.Infrastructure.Persistence.MongoDB;

namespace PedeAI.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MongoDbContext _context;

        public ProductRepository(MongoDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Product product)
        {
            await _context.Products.InsertOneAsync(product);
        }

        public async Task<Product> GetByIdAsync(string id)
        {
            return await _context.Products.Find(p => p.Id == id.ToString()).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.Find(p => true).ToListAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            await _context.Products.ReplaceOneAsync(p => p.Id == product.Id, product);
        }

        public async Task DeleteAsync(string id)
        {
            await _context.Products.DeleteOneAsync(p => p.Id == id);
        }
        public async Task DeleteAllAsync()
        {
            
            var todos = await GetAllAsync();
            
            foreach (var product in todos)
            {
                if (product.Id != null) await DeleteAsync(product.Id);
            }
        }
    }
}