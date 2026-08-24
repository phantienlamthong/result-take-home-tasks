using JtlDemo.Rest.Server;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Legacy configuration: the connection profile comes from the Windows registry.
var connectionString = builder.Configuration["ConnectionString"]
    ?? throw new InvalidOperationException(
        "Missing ConnectionString configuration.");
// Legacy diagnostics: startup is written to the Windows Event Log.
app.Logger.LogInformation("JtlDemo REST host starting");
app.MapGet("/healthz", () => Results.Ok(new { status = "ok" }));
app.MapGet("/api/_config", () => Results.Ok(new { configured = connectionString.Length > 0 }));

foreach (var module in ApiModuleCatalog.BuildApiModules())
{
    module.MapEndpoints(app);
}

app.Run();
