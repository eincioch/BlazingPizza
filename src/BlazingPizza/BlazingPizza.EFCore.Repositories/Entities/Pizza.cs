namespace BlazingPizza.EFCore.Repositories.Entities;
internal class Pizza
{
    public int Id { get; set; }
    public int OrderId { get; set; }

    // Solo para facilitar la recuperación de datos relacionados.
    public PizzaSpecial PizzaSpecial { get; set; }

    public int PizzaSpecialId { get; set; }
    public int Size { get; set; }
    public List<PizzaTopping> Toppings { get; set; }
}

