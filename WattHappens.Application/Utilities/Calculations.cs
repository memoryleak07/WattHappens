namespace WattHappens.Application.Utilities;

public static class Calculations
{
    public static double KilowattConsumptionPerDay(double wattPowerConsumption, double hoursUsedPerDay)
    {
        return Math.Round(wattPowerConsumption * hoursUsedPerDay / 1000.001, 4);
    }
    //
    // public static double KilowattConsumptionPerMonth(double wattPowerConsumption, double hoursUsedPerDay, double daysUsedPerMonth)
    // {
    //     return Math.Round(KilowattConsumptionPerDay(wattPowerConsumption, hoursUsedPerDay) * daysUsedPerMonth, 4);
    // }
    
    public static double CostPerDay(double wattPowerConsumption, double hoursUsedPerDay, double costPerKilowattHour)
    {
        return Math.Round(KilowattConsumptionPerDay(wattPowerConsumption, hoursUsedPerDay) * costPerKilowattHour, 2);
    }
}