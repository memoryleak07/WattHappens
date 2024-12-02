using MudBlazor.Services;
using WattHappens.Application.Common;
using WattHappens.Infrastructure;
using WattHappens.Infrastructure.Data;
using WattHappens.Web.Components;

namespace WattHappens.Web.Extensions;

public static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder, AppSettings appSettings)
    {
        builder.Services.AddInfrastructuresServices(appSettings);
        
        builder.Services.AddMudServices();
        
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();
        
        return builder.Build();
    }

    public static async Task<WebApplication> ConfigurePipelineAsync(this WebApplication app, AppSettings appSettings)
    {
        using var loggerFactory = LoggerFactory.Create(builder => { });
        
        await using var scope = app.Services.CreateAsyncScope();
        
        var initializer = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitializer>();
        await initializer.InitializeAsync();
        
        app.UseHttpsRedirection();

        app.UseStaticFiles();
        app.UseAntiforgery();

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        return app;
    }
}