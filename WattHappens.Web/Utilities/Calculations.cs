using WattHappens.Domain.Entities;

namespace WattHappens.Web.Utilities;

public static class Calculations
{
    #region WATT CONSUMPTION
    
    public static double KilowattConsumptionPerDay(Appliance appliance) => 
        Math.Round(appliance.Quantity * (appliance.WattPowerConsumption * appliance.HoursUsedPerDay) / 1000.001, 4);
    
    public static double KilowattConsumptionPerMonth(Appliance appliance) => 
        Math.Round(KilowattConsumptionPerDay(appliance) * 30.44, 4);
    
    public static double KilowattConsumptionPerYear(Appliance appliance) =>
        Math.Round(KilowattConsumptionPerDay(appliance) * 365.25, 4);

    # endregion
    
    #region COST CALCULATIONS
    
    public static double CostPerDay(Appliance appliance, Price price) => 
        Math.Round(KilowattConsumptionPerDay(appliance) * Math.Round(price.Cost, 2), 2);
    
    public static double CostPerMonth(Appliance appliance, Price price) =>
        Math.Round(KilowattConsumptionPerMonth(appliance) * Math.Round(price.Cost, 2), 2);
    
    public static double CostPerYear(Appliance appliance, Price price) =>
        Math.Round(KilowattConsumptionPerYear(appliance) * Math.Round(price.Cost, 2), 2);

    #endregion
}