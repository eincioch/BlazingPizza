namespace BlazingPizza.Backend.IoC;
public static class DependencyContainer
{
    public static IServiceCollection AddBlazingPizzaServices(
        this IServiceCollection services)
    {
        services.AddUseCasesServices()
        .AddRepositoriesServices()
        .AddControllersServices()
        .AddPresentersServices();

        return services;
    }
}
