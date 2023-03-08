namespace BlazingPizza.Models;
internal class OrderDetailsModel : IOrderDetailsModel
{
    readonly IBlazingPizzaWebApiGateway Gateway;
    public OrderDetailsModel(IBlazingPizzaWebApiGateway gateway)
    {
        Gateway = gateway;
    }

    public async Task<GetOrderDto> GetOrderAsync(int id)
    {
        return await Gateway.GetOrderAsync(id);
    }
}
