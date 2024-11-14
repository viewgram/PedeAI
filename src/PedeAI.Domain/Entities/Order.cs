using PedeAI.Domain.ValueObjects;

namespace PedeAI.Domain.Entities;

public class Order
{
    //validation missing
    
    public Guid Id { get; private set; }
    public DateTime CreatedAt { get; private set; }
    private readonly List<OrderItem> _items;

    public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();

    public Order()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
        _items = new List<OrderItem>();
    }

    public void AddItem(Product product, Quantity quantity)
    {
        var orderItem = new OrderItem(product, quantity);
        _items.Add(orderItem);
    }

    public decimal GetTotalAmount()
    {
        return _items.Sum(item => item.GetTotal());
    }
}
