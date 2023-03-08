var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


// Para que cualquier servicio que lo requiera, lo puede solicitar de
// IOptions<EndpointsOptions>
var BlazingPizzaEndpointsOptions =
    builder.Configuration.GetSection(
        EndpointsOptions.SectionKey)
    .Get<EndpointsOptions>();

builder.Services.Configure<EndpointsOptions>(options =>
    options = BlazingPizzaEndpointsOptions
);

builder.Services.AddBlazingPizzaFrontendServices(
    Options.Create(BlazingPizzaEndpointsOptions));

await builder.Build().RunAsync();
