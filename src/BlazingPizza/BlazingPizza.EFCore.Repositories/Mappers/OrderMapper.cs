namespace BlazingPizza.EFCore.Repositories.Mappers;
static class OrderMapper
{
    internal static EFEntities.Order ToEFOrder(
        this PlaceOrderOrderDto order) =>
        new EFEntities.Order()
        {
            CreatedTime = DateTime.Now,
            UserId = order.UserId,
            DeliveryAddress = order.DeliveryAddress.ToEFAddress(),
            DeliveryLocation = order.DeliveryLocation.ToEFLatLong(),
            Pizzas = order.Pizzas.Select(p => p.ToEFPizza()).ToList()
        };

    //internal static BusinessObjects.Aggregates.Order ToOrder(
    //    this EFEntities.Order order) =>
    //    BusinessObjects.Aggregates.Order.Create(
    //        order.Id, order.CreatedTime, order.UserId)
    //        .SetDeliveryAddress(order.DeliveryAddress.ToAddress())
    //        .SetDeliveryLocation(order.DeliveryLocation.ToLatLong())
    //        .AddPizzas(order.Pizzas?.Select(p => p.ToPizza()));

    internal static SharedAggregates.Order ToOrder(
    this EFEntities.Order order) =>
    SharedAggregates.Order.Create(
        order.Id, order.CreatedTime, order.UserId)
        .AddPizzas(order.Pizzas?.Select(p => p.ToPizza()));
}

