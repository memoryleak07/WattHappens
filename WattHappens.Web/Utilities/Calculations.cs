using WattHappens.Domain.Entities;

namespace WattHappens.Web.Utilities;

public static class Calculations
{
    private const int WattPrecision = 4;
    
    #region WATT CONSUMPTION
    
    private static double EfficiencyWattFinalRating(Appliance appliance) => 
        appliance.WattPowerConsumption * appliance.Efficiency / 100.0;
    
    public static double KilowattConsumptionPerDay(Appliance appliance) => 
        Math.Round(appliance.Quantity * (EfficiencyWattFinalRating(appliance) * appliance.HoursUsedPerDay) / 1000.001, WattPrecision);
    
    public static double KilowattConsumptionPerWeek(Appliance appliance) => 
        Math.Round(KilowattConsumptionPerDay(appliance) * appliance.DaysUsedPerWeek, WattPrecision);
    
    public static double KilowattConsumptionPerMonth(Appliance appliance) => 
        Math.Round(KilowattConsumptionPerWeek(appliance) * appliance.DaysUsedPerMonth, WattPrecision);
    
    public static double KilowattConsumptionPerYear(Appliance appliance) =>
        Math.Round(KilowattConsumptionPerMonth(appliance) * appliance.MonthsUsedPerYear, WattPrecision);

    # endregion
    
    #region COST CALCULATIONS
    
    public static double CostPerDay(Appliance appliance, Price price) => 
        Math.Round(KilowattConsumptionPerDay(appliance) * price.ElectricityCost, price.CostPrecision);
    
    public static double CostPerMonth(Appliance appliance, Price price) =>
        Math.Round(KilowattConsumptionPerMonth(appliance) * price.ElectricityCost, price.CostPrecision);
    
    public static double CostPerWeek(Appliance appliance, Price price) =>
        Math.Round(KilowattConsumptionPerWeek(appliance) * price.ElectricityCost, price.CostPrecision);
    
    public static double CostPerYear(Appliance appliance, Price price) =>
        Math.Round(KilowattConsumptionPerYear(appliance) * price.ElectricityCost, price.CostPrecision);

    #endregion
}