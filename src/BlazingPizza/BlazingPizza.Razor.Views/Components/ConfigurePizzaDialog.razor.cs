namespace BlazingPizza.Razor.Views.Components;
public partial class ConfigurePizzaDialog
{
    [Inject]
    public IConfigurePizzaDialogViewModel ViewModel { get; set; }

    [Parameter]
    public Pizza Pizza { get; set; }

    [Parameter]
    public EventCallback OnCancel { get; set; }
    [Parameter]
    public EventCallback OnConfirm { get; set; }

    protected async override Task OnInitializedAsync()
    {
        ViewModel.Pizza = Pizza;
        await ViewModel.GetToppingsAsync();
    }

    int MinimumPizzaSize => (int)PizzaSize.Minimum;
    int MaximumPizzaSize => (int)PizzaSize.Maximum;
    int IncrementPizzaSize => (int)PizzaSize.Increment;

    int ConfiguredPizzaSize
    {
        get => Pizza.Size;
        set => Pizza.SetSize(value);
    }

    void ToppingSelected(ChangeEventArgs e) =>
        ViewModel.AddTopping(ToppingAt(Convert.ToInt32(e.Value)));
    Topping ToppingAt(int index) =>
        ViewModel.Toppings.ElementAt(index);
}
