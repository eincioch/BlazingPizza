namespace BlazingPizza.Frontend.IoC;
public static class DependencyContainer
{
    public static IServiceCollection AddBlazingPizzaFrontendServices(
        this IServiceCollection services,
        IOptions<EndpointsOptions> endpoints,
        Action<IHttpClientBuilder> httpClientConfigurator = null)
    {
        services.AddModelsServices()
            .AddViewModelsServices()
            .AddBlazinPizzaWebApiGateways(endpoints, httpClientConfigurator);

        return services;
    }

    // Se puede mover a un proyecto Frontend.Desktop.IoC
    //public static IServiceCollection AddBlazingPizzaDesktopServices(
    //this IServiceCollection services)
    //{
    //    services.AddDesktopModelsServices()
    //        .AddViewModelsServices();

    //    return services;
    //}
}
