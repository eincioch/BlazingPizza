namespace BlazingPizza.EFCore.Repositories.DataContexts;
internal class BlazingPizzaQueriesContext : BlazingPizzaContext,
    IBlazingPizzaQueriesContext
{
    public BlazingPizzaQueriesContext(
        IOptions<ConnectionStringsOptions> connectionStringOptions)
        : base(connectionStringOptions)
    {
        ChangeTracker.QueryTrackingBehavior =
            QueryTrackingBehavior.NoTracking;       
    }
}
