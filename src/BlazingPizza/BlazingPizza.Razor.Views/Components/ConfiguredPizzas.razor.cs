namespace BlazingPizza.Razor.Views.Components;
public partial class ConfiguredPizzas
{
    [Parameter]
    public Order Order { get; set; }

    void RemoveConfiguredPizza(Pizza pizza)
    {
        Order.RemovePizza(pizza);
    }

    bool HasPizzas => 
        Order.Pizzas.Any();
}
