namespace BlazingPizza.EFCore.Repositories.DataContexts;
class BlazingPizzaContextFactory :
    IDesignTimeDbContextFactory<BlazingPizzaContext>
{
    public BlazingPizzaContext CreateDbContext(string[] args)
    {
        //var OptionsBuilder =
        //   new DbContextOptionsBuilder<BlazingPizzaContext>();
        //// La opción Encrypt es para deshabilitar el encriptamiento.
        //// La opción TrustServerCertificate=true acepta el certificado
        //OptionsBuilder.UseSqlServer(
        //    "Server=(localdb)\\mssqllocaldb;database=BlazingPizzaDB;");
        var ConnectionStringsOptions = new ConnectionStringsOptions
        { 
            BlazingPizzaDB =
            "Server=(localdb)\\mssqllocaldb;database=BlazingPizzaDB;"
        };

        return new BlazingPizzaContext(
            Options.Create(ConnectionStringsOptions));
    }
}

