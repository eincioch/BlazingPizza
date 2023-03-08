namespace BlazingPizza.WinFormsClient;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        RegisterServices();
    }

    void RegisterServices()
    {
        IServiceCollection Services = new ServiceCollection();
        Services.AddWindowsFormsBlazorWebView();

        Services.AddBlazorWebViewDeveloperTools();

        IConfiguration Configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();


        var BlazingPizzaEndpointsOptions =
            Configuration.GetSection(
                EndpointsOptions.SectionKey)
            .Get<EndpointsOptions>();

        Services.Configure<EndpointsOptions>(options =>
        options = BlazingPizzaEndpointsOptions);

        Services.AddBlazingPizzaFrontendServices(
            Options.Create(BlazingPizzaEndpointsOptions));

        blazorWebView1.HostPage = "wwwroot\\index.html";
        blazorWebView1.Services = Services.BuildServiceProvider();
        blazorWebView1.RootComponents
            .Add<App>("#app");
    }

}
