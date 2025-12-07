using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TallerMecanicoBlazor;
using TallerMecanicoBlazor.Frontend;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<ICustomerService, CustomerService>();


builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7019") 
});
builder.Services.AddSingleton<ApiConfig>(sp =>
{
    var config = sp.GetRequiredService<IConfiguration>();
    return new ApiConfig { ApiBaseUrl = config["ApiBaseUrl"]! };
});


await builder.Build().RunAsync();
