namespace BlazingPizza.EFCore.Repositories.Entities;
internal class PizzaTopping
{
    public int PizzaId { get; set; }

    // Solo para facilitar la recueperación de datos relacionados
    public Topping Topping { get; set; }

    public int ToppingId { get; set; }
}

