namespace WattHappens.Domain.Entities;

public class Price
{
    public int Id { get; set; }
    public double Cost { get; set; } // Energy price in €/kWh (euro per kilowatt-hour)
}