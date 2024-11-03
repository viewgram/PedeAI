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

    public decimal GetTotal()
    {
        return Product.Price.Amount * Quantity.Value;
    }
}
