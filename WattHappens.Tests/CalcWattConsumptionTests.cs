using WattHappens.Domain.Entities;
using WattHappens.Web.Utilities;

namespace WattHappens.Tests;

public class CalcWattConsumptionTests
{
    [Fact] 
    public void OneWattOneHourApplianceConsumptions()
    {
        var appliance = new Appliance
        {
            Quantity = 1,
            WattPowerConsumption = 1, // 1 W
            HoursUsedPerDay = 1,
            DaysUsedPerWeek = 7,
            DaysUsedPerMonth = 30,
            MonthsUsedPerYear = 12
        };

        var resultDay = Calculations.KilowattConsumptionPerDay(appliance);
        var resultWeek = Calculations.KilowattConsumptionPerWeek(appliance);
        var resultMonth = Calculations.KilowattConsumptionPerMonth(appliance);
        var resultYear = Calculations.KilowattConsumptionPerYear(appliance);

        Assert.Equal(0.001, resultDay);
        Assert.Equal(0.007, resultWeek);
        Assert.Equal(0.21, resultMonth);
        Assert.Equal(2.52, resultYear);
    }

    [Fact]
    public void TwoWattOneHourApplianceConsumptions()
    {
        var appliance = new Appliance
        {
            Quantity = 1,
            WattPowerConsumption = 2, // 2 W
            HoursUsedPerDay = 1,
            DaysUsedPerWeek = 7,
            DaysUsedPerMonth = 30,
            MonthsUsedPerYear = 12
        };
        
        var resultDay = Calculations.KilowattConsumptionPerDay(appliance);
        var resultWeek = Calculations.KilowattConsumptionPerWeek(appliance);
        var resultMonth = Calculations.KilowattConsumptionPerMonth(appliance);
        var resultYear = Calculations.KilowattConsumptionPerYear(appliance);

        Assert.Equal(0.002, resultDay);
        Assert.Equal(0.014, resultWeek);
        Assert.Equal(0.42, resultMonth);
        Assert.Equal(5.04, resultYear);
    }

    [Fact]
    public void TwoWattTwentyMinutesApplianceConsumptions()
    {
        var appliance = new Appliance
        {
            Quantity = 1,
            WattPowerConsumption = 2, // 2 W
            HoursUsedPerDay = 20/60.0, // 20 minutes
            DaysUsedPerWeek = 7,
            DaysUsedPerMonth = 30,
            MonthsUsedPerYear = 12
        };
        
        var resultDay = Calculations.KilowattConsumptionPerDay(appliance);
        var resultWeek = Calculations.KilowattConsumptionPerWeek(appliance);
        var resultMonth = Calculations.KilowattConsumptionPerMonth(appliance);
        var resultYear = Calculations.KilowattConsumptionPerYear(appliance);
        
        Assert.Equal(0.0007, resultDay);
        Assert.Equal(0.0049, resultWeek);
        Assert.Equal(0.147, resultMonth);
        Assert.Equal(1.764, resultYear);
    }
    
    [Fact]
    public void OneKilowattOneHourApplianceConsumptions()
    {
        var appliance = new Appliance
        {
            Quantity = 1,
            WattPowerConsumption = 1000, // 1 kW
            HoursUsedPerDay = 1,
            DaysUsedPerWeek = 7,
            DaysUsedPerMonth = 30,
            MonthsUsedPerYear = 12
        };

        var resultDay = Calculations.KilowattConsumptionPerDay(appliance);
        var resultWeek = Calculations.KilowattConsumptionPerWeek(appliance);
        var resultMonth = Calculations.KilowattConsumptionPerMonth(appliance);
        var resultYear = Calculations.KilowattConsumptionPerYear(appliance);

        Assert.Equal(1, resultDay);
        Assert.Equal(7, resultWeek);
        Assert.Equal(210, resultMonth);
        Assert.Equal(2520, resultYear);
    }
    
    [Fact]
    public void TwoKilowattTwentyMinutesApplianceConsumptions()
    {
        var appliance = new Appliance
        {
            Quantity = 1,
            WattPowerConsumption = 2000, // 2 kW
            HoursUsedPerDay = 20/60.0, // 20 minutes
            DaysUsedPerWeek = 7,
            DaysUsedPerMonth = 30,
            MonthsUsedPerYear = 12
        };

        var resultDay = Calculations.KilowattConsumptionPerDay(appliance);
        var resultWeek = Calculations.KilowattConsumptionPerWeek(appliance);
        var resultMonth = Calculations.KilowattConsumptionPerMonth(appliance);
        var resultYear = Calculations.KilowattConsumptionPerYear(appliance);

        Assert.Equal(0.6667, resultDay);
        Assert.Equal(4.6669, resultWeek);
        Assert.Equal(140.007, resultMonth);
        Assert.Equal(1680.084, resultYear);
    }
    
    [Fact]
    public void FiveKilowattOneHourApplianceConsumptions()
    {
        var appliance = new Appliance
        {
            Quantity = 1,
            WattPowerConsumption = 5000, // 5 kW
            HoursUsedPerDay = 1,
            DaysUsedPerWeek = 7,
            DaysUsedPerMonth = 30,
            MonthsUsedPerYear = 12
        };

        var resultDay = Calculations.KilowattConsumptionPerDay(appliance);
        var resultWeek = Calculations.KilowattConsumptionPerWeek(appliance);
        var resultMonth = Calculations.KilowattConsumptionPerMonth(appliance);
        var resultYear = Calculations.KilowattConsumptionPerYear(appliance);

        Assert.Equal(5, resultDay);
        Assert.Equal(35, resultWeek);
        Assert.Equal(1050, resultMonth);
        Assert.Equal(12600, resultYear);
    }
    
    [Fact]
    public void FiveKilowattTwentyMinutesApplianceConsumptions()
    {
        var appliance = new Appliance
        {
            Quantity = 1,
            WattPowerConsumption = 5000, // 5 kW
            HoursUsedPerDay = 20/60.0, // 20 minutes
            DaysUsedPerWeek = 7,
            DaysUsedPerMonth = 30,
            MonthsUsedPerYear = 12
        };

        var resultDay = Calculations.KilowattConsumptionPerDay(appliance);
        var resultWeek = Calculations.KilowattConsumptionPerWeek(appliance);
        var resultMonth = Calculations.KilowattConsumptionPerMonth(appliance);
        var resultYear = Calculations.KilowattConsumptionPerYear(appliance);

        Assert.Equal(1.6667, resultDay);
        Assert.Equal(11.6669, resultWeek);
        Assert.Equal(350.007, resultMonth);
        Assert.Equal(4200.084, resultYear);
    }
    
    [Fact]
    public void SevenDotFiveKilowattOneHourApplianceConsumptions()
    {
        var appliance = new Appliance
        {
            Quantity = 1,
            WattPowerConsumption = 7500, // 7.5 kW
            HoursUsedPerDay = 1,
            DaysUsedPerWeek = 7,
            DaysUsedPerMonth = 30,
            MonthsUsedPerYear = 12
        };

        var resultDay = Calculations.KilowattConsumptionPerDay(appliance);
        var resultWeek = Calculations.KilowattConsumptionPerWeek(appliance);
        var resultMonth = Calculations.KilowattConsumptionPerMonth(appliance);
        var resultYear = Calculations.KilowattConsumptionPerYear(appliance);

        Assert.Equal(7.5, resultDay);
        Assert.Equal(52.5, resultWeek);
        Assert.Equal(1575, resultMonth);
        Assert.Equal(18900, resultYear);
    }
    
    [Fact]
    public void SevenDotFiveKilowattTwentyMinutesApplianceConsumptions()
    {
        var appliance = new Appliance
        {
            Quantity = 1,
            WattPowerConsumption = 7500, // 7.5 kW
            HoursUsedPerDay = 20/60.0, // 20 minutes
            DaysUsedPerWeek = 7,
            DaysUsedPerMonth = 30,
            MonthsUsedPerYear = 12
        };

        var resultDay = Calculations.KilowattConsumptionPerDay(appliance);
        var resultWeek = Calculations.KilowattConsumptionPerWeek(appliance);
        var resultMonth = Calculations.KilowattConsumptionPerMonth(appliance);
        var resultYear = Calculations.KilowattConsumptionPerYear(appliance);

        Assert.Equal(2.5, resultDay);
        Assert.Equal(17.5, resultWeek);
        Assert.Equal(525, resultMonth);
        Assert.Equal(6300, resultYear);
    }
}