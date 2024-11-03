namespace PedeAI.Domain.ValueObjects;

public class Quantity
{
    public int Value { get; private set; }

    public Quantity(int value)
    {
        if (value < 0) throw new ArgumentException("Quantity cannot be negative");
        Value = value;
    }

    public Quantity Decrease(Quantity quantity)
    {
        return new Quantity(Value - quantity.Value);
    }
}
