using WattHappens.Application.Constants;

namespace WattHappens.Infrastructure.Data;

public class ApplicationDbContextInitializer(
    ApplicationDbContext context,
    ILoggerFactory logger)
{
    private readonly ILogger _logger = logger.CreateLogger<ApplicationDbContextInitializer>();

    public async Task InitializeAsync()
    {
        try
        {
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();
            await context.Database.MigrateAsync();
            await SeedDataAsync();
        }
        catch (Exception exception)
        {
            _logger.LogError("Migration error {exception}", exception);
            throw;
        }
    }

    private async Task SeedDataAsync()
    {
        var price = new Price
        {
            ElectricityCost = 0.30,
            CostPrecision = 2,
            WattPrecision = 4
        };
        
        var categories = new List<Category>
        {
            new() { Id = EnCategory.KitchenAppliances, Name = "Kitchen Appliances", Description = "Refrigerator, oven, microwave, etc."},
            new() { Id = EnCategory.LaundryAppliances, Name = "Laundry Appliances", Description = "Washer, dryer, etc."},
            new() { Id = EnCategory.ClimateControl, Name = "Climate Control", Description = "Air conditioner, heating, etc."},
            new() { Id = EnCategory.Entertainment, Name = "Entertainment", Description = "TVs, gaming consoles, sound systems, etc."},
            new() { Id = EnCategory.ComputingDevices, Name = "Computing Devices", Description = "Computers, laptops, nas, etc."},
            new() { Id = EnCategory.MobileDevices, Name = "Mobile Devices", Description = "Smartphones, tablets, etc."},
            new() { Id = EnCategory.Lighting, Name = "Lighting", Description = "Indoor and outdoor lighting."},
            new() { Id = EnCategory.Security, Name = "Security", Description = "Security cameras, alarms, etc."},
            new() { Id = EnCategory.OutdoorEquipment, Name = "Outdoor Equipment", Description = "Lawn mowers, pool pumps, electric grills, etc." },
            new() { Id = EnCategory.HealthAndFitness, Name = "Health & Fitness", Description = "Treadmills, stationary bikes, fitness equipment, etc." },
            new() { Id = EnCategory.WaterHeating, Name = "Water Heating", Description = "Water heaters, boilers, etc." },
            new() { Id = EnCategory.HobbyEquipment, Name = "Hobby Equipment", Description = "Power tools, sewing machines, 3D printers, etc." },
            new() { Id = EnCategory.Others, Name = "Others", Description = "Other devices not listed." }
        };

        var appliances = new List<Appliance>
        {
            new() { Name = "Refrigerator", Category = EnCategory.KitchenAppliances, Quantity = 1, WattPowerConsumption = 150, HoursUsedPerDay = 5, DaysUsedPerWeek = 3, DaysUsedPerMonth = 12, MonthsUsedPerYear = 12},
            new() { Name = "Electric Oven", Category = EnCategory.KitchenAppliances, Quantity = 1, WattPowerConsumption = 2000, HoursUsedPerDay = 20/60.0, DaysUsedPerWeek = 4, DaysUsedPerMonth = 24, MonthsUsedPerYear = 12 },
            new() { Name = "Microwave", Category = EnCategory.KitchenAppliances, Quantity = 1, WattPowerConsumption = 1000, HoursUsedPerDay = 0.5, DaysUsedPerWeek = 6, DaysUsedPerMonth = 9, MonthsUsedPerYear = 12 },
            new() { Name = "Washer", Category = EnCategory.LaundryAppliances, Quantity = 1, WattPowerConsumption = 500, HoursUsedPerDay = 1, DaysUsedPerWeek = 1, DaysUsedPerMonth = 11, MonthsUsedPerYear = 12},
            new() { Name = "Dryer", Category = EnCategory.LaundryAppliances, Quantity = 1, WattPowerConsumption = 5000, HoursUsedPerDay = 5.4, DaysUsedPerWeek = 5, DaysUsedPerMonth = 16, MonthsUsedPerYear = 12 },
            new() { Name = "Air Conditioner", Category = EnCategory.ClimateControl, Quantity = 1, WattPowerConsumption = 1500, HoursUsedPerDay = 8, DaysUsedPerWeek = 2, DaysUsedPerMonth = 5, MonthsUsedPerYear = 6 },
            // new() { Name = "Heating", Category = EnCategory.ClimateControl, Quantity = 1, WattPowerConsumption = 2000, HoursUsedPerDay = 8, DaysUsedPerMonth = 30 },
            // new() { Name = "TV", Category = EnCategory.Entertainment, Quantity = 1, WattPowerConsumption = 100, HoursUsedPerDay = 4, DaysUsedPerMonth = 30 },
            // new() { Name = "Gaming Console", Category = EnCategory.Entertainment, Quantity = 1, WattPowerConsumption = 150, HoursUsedPerDay = 4, DaysUsedPerMonth = 30 },
            // new() { Name = "Sound System", Category = EnCategory.Entertainment, Quantity = 1, WattPowerConsumption = 200, HoursUsedPerDay = 4, DaysUsedPerMonth = 30 },
            // new() { Name = "Computer", Category = EnCategory.ComputingDevices, Quantity = 1, WattPowerConsumption = 200, HoursUsedPerDay = 8, DaysUsedPerMonth = 30 },
            // new() { Name = "Laptop", Category = EnCategory.ComputingDevices, Quantity = 1, WattPowerConsumption = 50, HoursUsedPerDay = 8, DaysUsedPerMonth = 30 },
            // new() { Name = "NAS", Category = EnCategory.ComputingDevices, Quantity = 1, WattPowerConsumption = 50, HoursUsedPerDay = 24, DaysUsedPerMonth = 30 },
            // new() { Name = "Smartphone", Category = EnCategory.MobileDevices, Quantity = 1, WattPowerConsumption = 10, HoursUsedPerDay = 24, DaysUsedPerMonth = 30 },
            // new() { Name = "Tablet", Category = EnCategory.MobileDevices, Quantity = 1, WattPowerConsumption = 10, HoursUsedPerDay = 8, DaysUsedPerMonth = 30 },
            // new() { Name = "Indoor Lighting", Category = EnCategory.Lighting, Quantity = 10, WattPowerConsumption = 60, HoursUsedPerDay = 4, DaysUsedPerMonth = 30 },
            // new() { Name = "Outdoor Lighting", Category = EnCategory.Lighting, Quantity = 5, WattPowerConsumption = 60, HoursUsedPerDay = 4, DaysUsedPerMonth = 30 },
            // new() { Name = "Security Camera", Category = EnCategory.Security, Quantity = 1, WattPowerConsumption = 10, HoursUsedPerDay = 24, DaysUsedPerMonth = 30 },
            // new() { Name = "Alarm System", Category = EnCategory.Security, Quantity = 1, WattPowerConsumption = 10, HoursUsedPerDay = 24, DaysUsedPerMonth = 30 },
            // new() { Name = "Pool Pump", Category = EnCategory.OutdoorEquipment, Quantity = 1, WattPowerConsumption = 1500, HoursUsedPerDay = 8, DaysUsedPerMonth = 30 },
            // new() { Name = "Treadmill", Category = EnCategory.HealthAndFitness, Quantity = 1, WattPowerConsumption = 1000, HoursUsedPerDay = 1, DaysUsedPerMonth = 30 },
            // new() { Name = "Stationary Bike", Category = EnCategory.HealthAndFitness, Quantity = 1, WattPowerConsumption = 500, HoursUsedPerDay = 1, DaysUsedPerMonth = 30 },
            // new() { Name = "Water Heater", Category = EnCategory.WaterHeating, Quantity = 1, WattPowerConsumption = 4000, HoursUsedPerDay = 1, DaysUsedPerMonth = 30 },
            // new() { Name = "Power Tools", Category = EnCategory.HobbyEquipment, Quantity = 1, WattPowerConsumption = 1000, HoursUsedPerDay = 1, DaysUsedPerMonth = 30 },
            // new() { Name = "Sewing Machine", Category = EnCategory.HobbyEquipment, Quantity = 1, WattPowerConsumption = 100, HoursUsedPerDay = 1, DaysUsedPerMonth = 30 },
            // new() { Name = "3D Printer", Category = EnCategory.HobbyEquipment, Quantity = 1, WattPowerConsumption = 500, HoursUsedPerDay = 1, DaysUsedPerMonth = 30 },
            // new() { Name = "Other Device", Category = EnCategory.Others, Quantity = 1, WattPowerConsumption = 100, HoursUsedPerDay = 1, DaysUsedPerMonth = 30 }
        };
        
        await context.Prices.AddAsync(price);
        await context.Categories.AddRangeAsync(categories);
        await context.Appliances.AddRangeAsync(appliances);
        await context.SaveChangesAsync();
    }
}