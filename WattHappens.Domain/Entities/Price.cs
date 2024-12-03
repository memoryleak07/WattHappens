namespace WattHappens.Domain.Entities;

public class Price
{
    public int Id { get; init; }
    public double Cost { get; set; } // Energy price in €/kWh (euro per kilowatt-hour)
}