using PedeAI.Domain.Entities.Base;
using PedeAI.Domain.ValueObjects;

namespace PedeAI.Domain.Entities;

public abstract class Order : BaseEntity
{
    private readonly List<OrderItem> _items = new();

    public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();

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
