namespace BlazingPizza.ViewModels;
internal class IndexViewModel : IIndexViewModel
{
    readonly IOrderStateService OrderStateService;
    public IndexViewModel(IOrderStateService orderStateService)
    {
        OrderStateService = orderStateService;
    }

    public Pizza ConfiguringPizza { get; set; }
    public bool ShowingConfigureDialog { get; set; }

    public void ShowConfigurePizzaDialog(PizzaSpecial special)
    {
        ConfiguringPizza = new Pizza(special);

        ShowingConfigureDialog = true;
    }

    public void CancelConfigurePizzaDialog()
    {
        ConfiguringPizza = null;
        ShowingConfigureDialog = false;
    }

    public void ConfirmConfigurePizzaDialog()
    {
        OrderStateService.Order.AddPizza(ConfiguringPizza);

        ConfiguringPizza = null;
        ShowingConfigureDialog = false;

        foreach (var pizza in OrderStateService.Order.Pizzas)
            Console.WriteLine(pizza.Special.Name);

    }
}
