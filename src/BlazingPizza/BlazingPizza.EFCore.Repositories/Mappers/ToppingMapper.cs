namespace BlazingPizza.EFCore.Repositories.Mappers;
internal static class ToppingMapper
{
    internal static Topping ToTopping(
        this Repositories.Entities.Topping topping) =>
        new Topping
        {
            Id = topping.Id,
            Name = topping.Name,
            Price = topping.Price
        };
}
