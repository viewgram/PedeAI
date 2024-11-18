using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using PedeAI.Domain.Entities.Base;
using PedeAI.Domain.Validation;
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

        private void ValidateProduct(string id, string name, Price price, Quantity stockQuantity)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(id),
                "Invalid Id, Id is required");
            
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid Name, Name is required");
            
            DomainExceptionValidation.When(Name.Length < 2,
                "Name must be at least 2 characters long");

            Id = id;
            Name = name;
            Price = price;
            StockQuantity = stockQuantity;
        }

        //update is missing
    }
}