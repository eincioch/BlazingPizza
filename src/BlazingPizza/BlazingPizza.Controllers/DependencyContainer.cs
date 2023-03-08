using BlazingPizza.Controllers.GetOrder;
using BlazingPizza.Controllers.GetOrders;
using BlazingPizza.Controllers.PlaceOrder;

namespace BlazingPizza.Controllers;
public static class DependencyContainer
{
    public static IServiceCollection AddControllersServices(
        this IServiceCollection services)
    {
        services.AddScoped<IGetSpecialsController,
        GetSpecialsController>();

        services.AddScoped<IGetToppingsController,
            GetToppingsController>();

        services.AddScoped<IPlaceOrderController, 
            PlaceOrderController>();

        services.AddScoped<IGetOrdersController,
            GetOrdersController>();

        services.AddScoped<IGetOrderController,
            GetOrderController>();

        return services;

    }
}
