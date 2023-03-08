namespace BlazingPizza.Razor.Views.Pages;

public partial class Checkout
{
    [Inject]
    public ICheckoutViewModel ViewModel { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }


    async Task PlaceOrder()
    {
        int OrderId = await ViewModel.PlaceOrderAsync();
        if(OrderId > 0) 
        {
            NavigationManager.NavigateTo($"orderdetails/{OrderId}");
        }        
    }

}