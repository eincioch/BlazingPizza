namespace BlazingPizza.EFCore.Repositories.DataContexts;
internal class BlazingPizzaContext : DbContext
{
    readonly ConnectionStringsOptions ConnectionStringOptions;
    public BlazingPizzaContext(       
        IOptions<ConnectionStringsOptions> connectionStringOptions)        
    {
        ConnectionStringOptions = connectionStringOptions.Value;
        Console.WriteLine($"*** Constructor {this.GetType()}***");
    }
    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            ConnectionStringOptions.BlazingPizzaDB);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            Assembly.GetExecutingAssembly());
    }

    public DbSet<Repositories.Entities.PizzaSpecial> Specials { get; set; }
    public DbSet<Repositories.Entities.Topping> Toppings { get; set; }
    public DbSet<EFEntities.Pizza> Pizzas { get; set; }
    public DbSet<EFEntities.Order> Orders { get; set; }


    public override void Dispose()
    {
        Console.WriteLine($"**** Dispose {this.GetType()}****");
        base.Dispose();
    }
    public override ValueTask DisposeAsync()
    {
        Console.WriteLine($"**** DisposeAsync {this.GetType()}****");
        return base.DisposeAsync();
    }
}

