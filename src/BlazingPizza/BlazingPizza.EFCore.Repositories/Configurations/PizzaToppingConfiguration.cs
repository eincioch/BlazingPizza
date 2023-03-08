namespace BlazingPizza.EFCore.Repositories.Configurations;
class PizzaToppingConfiguration :
    IEntityTypeConfiguration<EFEntities.PizzaTopping>
{
    public void Configure(EntityTypeBuilder<EFEntities.PizzaTopping> builder)
    {
        // Definir la llave primaria de la entidad PizzaTopping
        builder.HasKey(pt => new { pt.PizzaId, pt.ToppingId });

        // Una Pizza puede tener muchos Toppings.
        builder.HasOne<EFEntities.Pizza>().WithMany(p => p.Toppings);

        // Un Topping puede estar en muchas Pizzas.
        builder.HasOne(pt => pt.Topping)
            .WithMany();
    }
}

