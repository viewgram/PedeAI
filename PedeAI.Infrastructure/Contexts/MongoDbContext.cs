using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PedeAI.Domain.Entities;
using PedeAI.Infrastructure.Configurations;

namespace PedeAI.Infrastructure;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(IOptions<MongoDbSettings> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionString);
        _database = client.GetDatabase(settings.Value.DatabaseName);
    }

    public IMongoCollection<Product> Products => _database.GetCollection<Product>("Products");
    public IMongoCollection<Order> Orders => _database.GetCollection<Order>("Orders");
}
