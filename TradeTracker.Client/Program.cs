using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TradeTracker.Client;
using MudBlazor.Services;  // <- přidáno pro MudBlazor

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Přidání MudBlazor
builder.Services.AddMudServices();

// HttpClient pro volání API nebo jiné požadavky
builder.Services.AddScoped(sp => new HttpClient 
{ 
    // Váš Server běží na HTTP. Nastavte HTTP a port 5173.
    BaseAddress = new Uri("http://localhost:5173/") 
});
await builder.Build().RunAsync();
