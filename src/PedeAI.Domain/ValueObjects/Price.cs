namespace PedeAI.Domain.ValueObjects;

public class Price
{
    public decimal Amount { get; private set; }

    public Price(decimal amount)
    {
        if (amount < 0) throw new ArgumentException("Price cannot be negative");
        Amount = amount;
    }
}
