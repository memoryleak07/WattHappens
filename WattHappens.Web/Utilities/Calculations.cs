using WattHappens.Domain.Entities;

namespace WattHappens.Web.Utilities;

public static class Calculations
{
    public static double KilowattConsumptionPerDay(Appliance appliance)
    {
        return Math.Round(appliance.WattPowerConsumption * appliance.HoursUsedPerDay / 1000.001, 4);
    }
    public static double CostPerDay(Appliance appliance, Price price)
    {
        return Math.Round(KilowattConsumptionPerDay(appliance) * Math.Round(price.Cost, 2), 2);
    }
}