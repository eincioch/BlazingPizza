namespace BlazingPizza.Shared.BusinessObjects.Dtos;
// Debe ser declarado como struct para que pueda crearse un
// constructor sin parametros y pueda devolverse un
// objeto vacío.
public record struct GetOrderDto(
    int Id, DateTime CreatedTime, string UserId,
    IReadOnlyCollection<PizzaDto> Pizzas,
    OrderStatus Status,
    bool IsDelivered)
{
    public decimal GetTotalPrice() =>
        Pizzas.Sum(p => p.GetTotalPrice());
    public string GetFormattedTotalPrice() =>
        GetTotalPrice().ToString("$ #,###.##");
}
