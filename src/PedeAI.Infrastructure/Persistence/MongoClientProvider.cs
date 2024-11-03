using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace PedeAI.Infrastructure.Persistence
{
    public class MongoClientProvider
    {
        private readonly IMongoClient _mongoClient;

        public MongoClientProvider(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ConnectionString");
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException("Connection string para MongoDB não foi configurada.");
            }

            try
            {
                // Cria o cliente MongoDB
                _mongoClient = new MongoClient(connectionString);

                // Teste inicial de conexão com o MongoDB
                var databaseName = "products_db"; // Nome do banco que deseja verificar
                var database = _mongoClient.GetDatabase(databaseName);
                database.RunCommand<BsonDocument>(new BsonDocument("ping", 1));
                Console.WriteLine("Conectado ao MongoDB com sucesso!");
            }
            catch (MongoConfigurationException ex)
            {
                Console.WriteLine($"Erro de configuração do MongoDB: {ex.Message}");
                throw;
            }
            catch (MongoConnectionException ex)
            {
                Console.WriteLine($"Erro de conexão com o MongoDB: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro inesperado ao conectar ao MongoDB: {ex.Message}");
                throw;
            }
        }

        public IMongoClient GetClient() => _mongoClient;
    }
}