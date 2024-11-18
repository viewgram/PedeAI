using PedeAI.Domain.Validation;
using PedeAI.Domain.ValueObjects;

namespace PedeAI.Domain.Entities;

public class OrderItem
{
    public Product Product { get; private set; }
    public Quantity Quantity { get; private set; }

    public OrderItem(Product product, Quantity quantity)
    {
        Product = product;
        Quantity = quantity;
    }

    private void ValidateOderItem(Product product, Quantity quantity)
    {
        DomainExceptionValidation.When(Product == null,
            "Product cannot be null.");
        
        //validação de estoque
    }
    
    public decimal GetTotal()
    {
        return Product.Price.Amount * Quantity.Value;
    }
}
