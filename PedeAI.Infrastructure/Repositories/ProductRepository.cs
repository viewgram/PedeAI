using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PedeAI.Domain.Entities;
using PedeAI.Domain.Interfaces;
using PedeAI.Infrastructure.Configurations;

namespace PedeAI.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<Product> _products;

        public ProductRepository(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _products = database.GetCollection<Product>("Products");
        }

        public async Task AddAsync(Product product)
        {
            await _products.InsertOneAsync(product);
        }

        public async Task<Product> GetByIdAsync(string id)
        {
            return await _products.Find(p => p.Id == id.ToString()).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _products.Find(p => true).ToListAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            await _products.ReplaceOneAsync(p => p.Id == product.Id, product);
        }

        public async Task DeleteAsync(string id)
        {
            await _products.DeleteOneAsync(p => p.Id == id);
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