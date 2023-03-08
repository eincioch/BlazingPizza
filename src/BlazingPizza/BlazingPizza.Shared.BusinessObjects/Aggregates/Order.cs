namespace BlazingPizza.Shared.BusinessObjects.Aggregates;
public class Order : BaseOrder
{
    public Order()
    {
        PizzasField = new();

    }

    public static Order Create(int orderId, DateTime createdTime,
        string userId)
    {
        Order Result = new Order();
        Result.Id = orderId;
        Result.CreatedTime = createdTime;
        Result.UserId = userId;
        return Result;
    }

    readonly List<Pizza> PizzasField;
    public Address DeliveryAddress { get; private set; } =
        new Address();
    public LatLong DeliveryLocation { get; private set; } = new();
    public IReadOnlyCollection<Pizza> Pizzas =>
        PizzasField;

    public void AddPizza(Pizza pizza)
    {
        PizzasField.Add(pizza);
    }

    public Order AddPizzas(IEnumerable<Pizza> pizzas)
    {
        if (pizzas != null)
        {
            PizzasField.AddRange(pizzas);
        }
        return this;
    }

    public void RemovePizza(Pizza pizza)
    {
        PizzasField.Remove(pizza);
    }
    public Order SetDeliveryAddress(Address deliverAddress)
    {
        DeliveryAddress = deliverAddress;
        return this;
    }
    public Order SetDeliveryLocation(LatLong deliverLocation)
    {
        DeliveryLocation = deliverLocation;
        return this;
    }

    public decimal GetTotalPrice() =>
            PizzasField.Sum(p => p.GetTotalPrice());

    public string GetFormattedTotalPrice() =>
        GetTotalPrice().ToString("#,###.##");

    public static explicit operator PlaceOrderOrderDto(Order order) =>
    new PlaceOrderOrderDto
    {
        UserId = order.UserId,
        DeliveryAddress = order.DeliveryAddress,
        DeliveryLocation = order.DeliveryLocation,
        Pizzas = order.Pizzas.Select(p => (PlaceOrderPizzaDto)p).ToList()
    };

    public static implicit operator Order(GetOrderDto order)
    {
        Order NewOrder = new Order
        {
            Id = order.Id,
            CreatedTime = order.CreatedTime,
            UserId = order.UserId
        };
        foreach (var Item in order.Pizzas)
        {
            NewOrder.AddPizza(Item);
        }

        return NewOrder;
    }

}
