namespace BlazingPizza.Shared.BusinessObjects.Enums;
public enum PizzaSize
{
    Default = 30,
    Minimum = 20,
    Maximum = 40,
    Increment = 2
}

public static class PizzaSizeExtension
{
    public static int Value(this PizzaSize size) =>
        (int)size;
}
