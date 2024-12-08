namespace WattHappens.Domain.Entities;

public class Price
{
    public int Id { get; init; }
    public double ElectricityCost { get; set; } // Electricity energy price in €/kWh (euro per kilowatt-hour)
    
    public int Precision { get; set; } // Number of decimal places to round to
}