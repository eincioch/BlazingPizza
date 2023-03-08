namespace BlazingPizza.Gateways;
internal class BlazingPizzaWebApiGateway : IBlazingPizzaWebApiGateway
{
    readonly HttpClient Client;
    readonly EndpointsOptions Endpoints;

    // IOptions requiere del paquete Microsoft.Extensions.Options
    public BlazingPizzaWebApiGateway(HttpClient client,
        IOptions<EndpointsOptions> endpointsOptions)
    {
        Client = client;
        Endpoints = endpointsOptions.Value;
    }

    public async Task<IReadOnlyCollection<PizzaSpecial>> GetSpecialsAsync()
    {
        return await Client
            .GetFromJsonAsync<IReadOnlyCollection<PizzaSpecial>>(
                Endpoints.Specials);
    }

    public async Task<IReadOnlyCollection<Topping>> GetToppingsAsync()
    {
        return await Client
            .GetFromJsonAsync<IReadOnlyCollection<Topping>>(
                Endpoints.Toppings);
    }

    public async Task<int> PlaceOrderAsync(Order order)
    {
        int OrderId = 0;
        var Response = await Client
            .PostAsJsonAsync(Endpoints.PlaceOrder,
                (PlaceOrderOrderDto)order);
        if (Response.IsSuccessStatusCode)
        {
            OrderId = await Response.Content.ReadFromJsonAsync<int>();
        }

        return OrderId;
    }

    public async Task<IReadOnlyCollection<GetOrdersDto>> GetOrdersAsync()
    {
        return await Client
            .GetFromJsonAsync<IReadOnlyCollection<GetOrdersDto>>(
            Endpoints.GetOrders);
    }

    public async Task<GetOrderDto> GetOrderAsync(int id)
    {
        return await Client
            .GetFromJsonAsync<GetOrderDto>(
            $"{Endpoints.GetOrder}/{id}");
    }


}
