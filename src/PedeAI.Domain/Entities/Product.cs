using PedeAI.Domain.Entities.Base;
using PedeAI.Domain.ValueObjects;

namespace PedeAI.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public Price Price { get; set; }
        public Quantity StockQuantity { get; set; }

        public Product(string name, Price price, Quantity stockQuantity)
        {
            Name = name;
            Price = price;
            StockQuantity = stockQuantity;
        }
    }
}