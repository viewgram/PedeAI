using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using PedeAI.Domain.Entities;

namespace PedeAI.Infrastructure.Persistence.MongoDB
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IConfiguration configuration)
        {
            var connectionUri = configuration.GetConnectionString("MongoDb");
            var settings = MongoClientSettings.FromConnectionString(connectionUri);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);

            // Verifica a conexão
            try
            {
                client.GetDatabase("Cluster0").RunCommand<BsonDocument>(new BsonDocument("ping", 1));
                Console.WriteLine("Conectado ao MongoDB com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao conectar ao MongoDB: {ex.Message}");
                throw;
            }

            _database = client.GetDatabase("Cluster0");
        }
        public IMongoCollection<Product> Products => _database.GetCollection<Product>("Products");
        // public IMongoCollection<YourEntity> YourEntities => _database.GetCollection<YourEntity>("YourEntitiesCollection");
        
        // Adicione mais coleções conforme necessário
    }
}