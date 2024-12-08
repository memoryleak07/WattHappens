namespace WattHappens.Domain.Entities;

public class Price
{
    public int Id { get; init; }
    public double ElectricityCost { get; set; } // Electricity energy price in €/kWh (euro per kilowatt-hour)
    public int CostPrecision { get; set; } // Number of decimal places to round to
    public int WattPrecision { get; set; } // Number of decimal places to round to
}