using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using PedeAI.Domain.Entities.Base;
using PedeAI.Domain.ValueObjects;

namespace PedeAI.Domain.Entities
{
    public class Product : BaseEntity
    {
        //MongoDBPackage deveria estar na infrastructure 
        //validation missing
        
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public Price Price { get; set; }
        public Quantity StockQuantity { get; set; }

        public Product(string name, Price price, Quantity stockQuantity)
        {
            Name = name;
            Price = price;
            StockQuantity = stockQuantity;
        }
        
        //update is missing
    }
}