namespace BlazingPizza.EFCore.Repositories.Mappers;
static class PizzaMapper
{
    internal static EFEntities.Pizza ToEFPizza(
       this PlaceOrderPizzaDto pizza) =>
        new EFEntities.Pizza
        {
            // Id será el Id que se asigne al insertar en la DB
            // OrderId será el que se asigne a la orden al ser insertada en la DB
            PizzaSpecialId = pizza.PizzaSpecialId,
            Size = pizza.Size,
            Toppings = pizza.ToppingsIds
                .Select(id => new Entities.PizzaTopping
                {
                    // PizzaId será el Id que se asigne a esta piiza al ser insertada en la DB 
                    ToppingId = id
                }).ToList()
        };

    internal static SharedAggregates.Pizza ToPizza(
        this EFEntities.Pizza pizza)
    {
        var Pizza = new SharedAggregates.Pizza(
            pizza.PizzaSpecial.ToPizzaSpecial());
        Pizza.SetSize(pizza.Size);
        pizza.Toppings?
            .ForEach(p => Pizza.AddTopping(p.Topping.ToTopping()));
        return Pizza;
    }

}

