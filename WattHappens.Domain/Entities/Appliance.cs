using WattHappens.Application.Constants;

namespace WattHappens.Domain.Entities;

public class Appliance
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Note { get; set; } = string.Empty;
    public EnCategory Category { get; set; }
    public int Quantity { get; set; }
    public double WattPowerConsumption { get; set; } // Power in Watts
    public double HoursUsedPerDay { get; set; } // Usage per day in hours
    public double DaysUsedPerMonth { get; set; } // Usage per month in days
}