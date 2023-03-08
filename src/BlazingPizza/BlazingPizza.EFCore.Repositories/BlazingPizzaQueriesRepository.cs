namespace BlazingPizza.EFCore.Repositories;
internal class BlazingPizzaQueriesRepository : 
    IBlazingPizzaQueriesRepository
{
    readonly IBlazingPizzaQueriesContext Context;

    public BlazingPizzaQueriesRepository(
        IBlazingPizzaQueriesContext context)
    {
        Context = context;       
    }

    public async Task<IReadOnlyCollection
        <PizzaSpecial>> GetSpecialsAsync()
    {
        return await Context.Specials
        .Select(s => s.ToPizzaSpecial())
        .ToListAsync();
    }

    public async Task<IReadOnlyCollection<Topping>> GetToppingsAsync()
    {
        return await Context.Toppings
            .Select(t => t.ToTopping())
            .ToListAsync();

    }
        
    public async Task<IReadOnlyCollection<GetOrdersDto>> GetOrdersAsync()
    {
        var Orders = await Context.Orders
            .Include(o => o.Pizzas).ThenInclude(p => p.PizzaSpecial)
            .Include(o => o.Pizzas).ThenInclude(p => p.Toppings)
                .ThenInclude(t => t.Topping)
            .OrderByDescending(o => o.CreatedTime)
            .ToListAsync();
        return Orders.Select(o => 
            GetOrdersDtoFake(o.ToOrder())).ToList();
    }


    public async Task<GetOrderDto> GetOrderAsync(int id)
    {
        var Order = await Context.Orders
            .Where(o => o.Id == id)
            .Include(o => o.Pizzas).ThenInclude(p => p.PizzaSpecial)
            .Include(o => o.Pizzas).ThenInclude(p => p.Toppings)
                .ThenInclude(t => t.Topping)
            .FirstOrDefaultAsync();

        return Order == null ? new GetOrderDto() :
            GetOrderDtoFake(Order.ToOrder());
    }

    #region Código para simular el estado de una orden.
    // TODO. Implementar con algún servicio la actualización del estado en la DB

    GetOrderDto GetOrderDtoFake(Order order)
    {
        OrderStatus Status;
        bool IsDelivered;
        GetStatus(order, out Status, out IsDelivered);

        return new GetOrderDto(
            order.Id, order.CreatedTime, order.UserId,
            order.Pizzas.Select(p => (PizzaDto)p).ToList(),
            Status,
            IsDelivered);
    }
    GetOrdersDto GetOrdersDtoFake(Order order)
    {
        OrderStatus Status;
        bool IsDelivered;
        GetStatus(order, out Status, out IsDelivered);

        return new GetOrdersDto(
            order.Id, order.CreatedTime,order.UserId,
            order.Pizzas.Count,
            order.GetTotalPrice(),
            Status,
            IsDelivered);
    }

    void GetStatus(Order order, 
        out OrderStatus status, out bool isDelivered) 
    {
        // Para simular un proceso real en el backend, 
        // simularemos cambios en el estatus basándonos en 
        // el tiempo transcurrido desde que la orden fue realizada.

        // Simular el tiempo de preparación de la orden.
        TimeSpan PreparationDurationTime =
            TimeSpan.FromSeconds(10);

        // Simular el tiempo en que tarda el repartidor en entregar
        // la orden.
        
        TimeSpan DeliveryDurationTime =
            TimeSpan.FromMinutes(1);

        // Tiempo en que se despacha a entrega el pedido.
        DateTime DispatchTime = 
            order.CreatedTime.Add(PreparationDurationTime);

        if (DateTime.Now < DispatchTime)
        {
            status = OrderStatus.Preparing;
        }
        else if (DateTime.Now < DispatchTime + DeliveryDurationTime)
        {
            status = OrderStatus.OutForDelivery;
        }
        else
        {
            status = OrderStatus.Delivered;
        }

        isDelivered = status == OrderStatus.Delivered;
        
    }

    #endregion
}
