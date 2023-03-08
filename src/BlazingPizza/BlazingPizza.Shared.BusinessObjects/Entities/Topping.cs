namespace BlazingPizza.Shared.BusinessObjects.Entities;
public class Topping
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string GetFormattedPrice() =>
        Price.ToString("$0.00");
    public string GetFormattedToppingNameWithPrice() =>
        $"{Name} - ({GetFormattedPrice()})";

}
