using WattHappens.Application.Constants;

namespace WattHappens.Domain.Entities;

public class Appliance
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Note { get; set; } = string.Empty;
    public EnCategory Category { get; set; } // Category of the device
    public EnEnergyClass ClassEnergy { get; set; } = EnEnergyClass.None; // Energy class
    public int Quantity { get; set; } = 1; // How many devices
    public int Efficiency { get; set; } = 100; // Efficiency in percentage
    public double WattPowerConsumption { get; set; } // Power in Watts
    public double HoursUsedPerDay { get; set; } // Usage per day in hours
    public double DaysUsedPerWeek { get; set; } = 7; // Usage per week in days
    public double DaysUsedPerMonth { get; set; } = 30; // Usage per month in days
}