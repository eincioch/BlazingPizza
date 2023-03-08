namespace BlazingPizza.Gateways;
public static class DependencyContainer
{
    public static IServiceCollection AddBlazinPizzaWebApiGateways(
        this IServiceCollection services,
        IOptions<EndpointsOptions> endpoints,
        Action<IHttpClientBuilder> httpClientConfigurator = null)
    {
        IHttpClientBuilder Builder =
            services.AddHttpClient<IBlazingPizzaWebApiGateway,
            BlazingPizzaWebApiGateway>(httpClient =>
            {
                httpClient.BaseAddress =
                    new Uri(endpoints.Value.WebApiBaseAddress);
                return new BlazingPizzaWebApiGateway(httpClient, endpoints);
            });

        httpClientConfigurator?.Invoke(Builder);

        return services;
    }
}
