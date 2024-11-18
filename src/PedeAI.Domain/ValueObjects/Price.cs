namespace PedeAI.Domain.ValueObjects;

public class Price
{
    // valueObjects fica dentro de services
    
    public decimal Amount { get; private set; }

    public Price(decimal amount)
    {
        if (amount < 0) throw new ArgumentException("Price cannot be negative");
        Amount = amount;
    }
}
