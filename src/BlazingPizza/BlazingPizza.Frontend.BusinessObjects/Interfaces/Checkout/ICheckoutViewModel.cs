namespace BlazingPizza.Frontend.BusinessObjects.Interfaces.Checkout;
public interface ICheckoutViewModel
{
    bool IsSubmitting { get; }
    Order Order { get; }
    Address Address { get; }
    Task<int> PlaceOrderAsync();
    bool? IsValidAddress { get; }
}
