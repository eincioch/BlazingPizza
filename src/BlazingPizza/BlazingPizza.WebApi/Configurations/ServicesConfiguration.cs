namespace BlazingPizza.WebApi.Configurations;

internal static class ServicesConfiguration
{
    public static WebApplication ConfigureWebApiServices(
        this WebApplicationBuilder builder)
    {


        // Configurar APIExplorer para descubrir y exponer
        // los metadatos de los endpoints de la aplicación.
        builder.Services.AddEndpointsApiExplorer();

        // Agregar el generador que construye los objetos de
        // documentación de Swagger con la funcionalidad del APIExplorer.
        builder.Services.AddSwaggerGen();

        builder.Services.Configure<SpecialsOptions>(
            builder.Configuration.GetSection(
                SpecialsOptions.SectionKey));

        //var ConnectionStringsOptions = 
        //    builder.Configuration.GetSection("ConnectionStrings")
        //    .Get<ConnectionStringsOptions>();

        //builder.Services.Configure<ConnectionStringsOptions>(options =>
        //    options.BlazingPizzaDB = ConnectionStringsOptions.BlazingPizzaDB);

        builder.Services.Configure<ConnectionStringsOptions>(
            builder.Configuration.GetSection(
                ConnectionStringsOptions.SectionKey));

        // Registrar los servicios de la aplicación
        builder.Services.AddBlazingPizzaServices();


        // Agregar el servicio CORS para clientes que se ejecutan
        // en el navegador Web (como Blazor WebAssembly).
        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(config =>
            {
                config.AllowAnyMethod();
                config.AllowAnyHeader();
                config.AllowAnyOrigin();
            });
        });

        return builder.Build();
    }
}

