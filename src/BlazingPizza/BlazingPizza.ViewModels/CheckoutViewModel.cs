using BlazingPizza.Shared.BusinessObjects.ValueObjects;
using System.Reflection;
using System.Xml.Linq;

namespace BlazingPizza.ViewModels;
internal class CheckoutViewModel : ICheckoutViewModel
{
    readonly ICheckoutModel Model;
    readonly IOrderStateService OrderStateService;

    public CheckoutViewModel(ICheckoutModel model,
        IOrderStateService orderStateService)
    {
        Model = model;
        OrderStateService = orderStateService;
    }

    public bool IsSubmitting { get; private set; }
    public Order Order => OrderStateService.Order;
    public Address Address { get; private set; } = new Address();
    public async Task<int> PlaceOrderAsync()
    {
        IsSubmitting = true;
        int OrderId = 0;
        if (IsValidAddress.HasValue && IsValidAddress.Value)
        {
            Order.SetDeliveryAddress(Address);
            OrderId = await Model.PlaceOrderAsync(
                OrderStateService.Order);
            OrderStateService.ResetOrder();
        }
        IsSubmitting = false;
        return OrderId;
    }

    public bool? IsValidAddress => string.IsNullOrWhiteSpace(Address.Name)
        || string.IsNullOrWhiteSpace(Address.AddressLine1)
        || string.IsNullOrWhiteSpace(Address.PostalCode);
}

