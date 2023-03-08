namespace BlazingPizza.Controllers.GetToppings;
internal class GetToppingsController : IGetToppingsController
{
    readonly IGetToppingsInputPort Inputport;

    public GetToppingsController(IGetToppingsInputPort inputport)
    {
        Inputport = inputport;
    }

    public async Task<IReadOnlyCollection<Topping>> GetToppingsAsync()
    {
        return await Inputport.GetToppingsAsync();
    }
}
