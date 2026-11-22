using SistemaNominaQuincenal.Components;
using SistemaNominaQuincenal.Services;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios de Razor Components (Blazor)
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Registrar e inicializar el cliente de Supabase
builder.Services.AddSingleton<Supabase.Client>(provider =>
{
    var config = provider.GetRequiredService<IConfiguration>();
    var url = config["SupabaseSettings:Url"]
              ?? throw new InvalidOperationException("Falta configurar SupabaseSettings:Url en appsettings.json");
    var key = config["SupabaseSettings:Key"]
              ?? throw new InvalidOperationException("Falta configurar SupabaseSettings:Key en appsettings.json");

    var client = new Supabase.Client(url, key);
    client.InitializeAsync().GetAwaiter().GetResult();
    return client;
});

// Registrar el servicio de cálculo de nómina (Nicaragua)
builder.Services.AddScoped<NominaCalculatorService>();

var app = builder.Build();

// Configurar el pipeline de solicitudes HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();