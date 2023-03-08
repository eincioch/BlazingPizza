namespace BlazingPizza.EFCore.Repositories.Configurations;
class OrderConfiguration :
    IEntityTypeConfiguration<EFEntities.Order>
{
    public void Configure(EntityTypeBuilder<EFEntities.Order> builder)
    {
        // Definir LatLong como un Owned Entity Type de Order.
        // Con esto las propiedades de la entidad LatLong se crearán en la tabla Order 
        // en lugar de crear una nueva tabla y una llave foránea para relacionarlas.
        builder.OwnsOne(o => o.DeliveryLocation);

        // La relación con DeliveryAddress y Pizza se hacen por convención.
    }
}
