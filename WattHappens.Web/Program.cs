using MudBlazor.Services;
using WattHappens.Application.Common;
using WattHappens.Web.Components;
using WattHappens.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration.Get<AppSettings>()
                    ?? throw new ArgumentNullException(nameof(AppSettings));

builder.Services.AddSingleton(configuration);

var app = await builder.ConfigureServices(configuration).ConfigurePipelineAsync(configuration);

await app.RunAsync();