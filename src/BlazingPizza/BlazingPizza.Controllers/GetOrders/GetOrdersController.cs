namespace BlazingPizza.Controllers.GetOrders;
internal class GetOrdersController : IGetOrdersController
{
    readonly IGetOrdersInputPort InputPort;

    public GetOrdersController(IGetOrdersInputPort inputPort)
    {
        InputPort = inputPort;
    }

    public async Task<IReadOnlyCollection<GetOrdersDto>> GetOrdersAsync()
    {
        return await InputPort.GetOrdersAsync();
    }
}

