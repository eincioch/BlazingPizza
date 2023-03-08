namespace BlazingPizza.WebApi.Configurations;

internal static class MiddlewaresConfiguration
{
    public static WebApplication ConfigureWebApiMiddlewares(
        this WebApplication app)
    {
        // Habilitar el middleware para servir el documento
        // JSON generado y la interfaz UI de Swagger en el
        // ambiente de desarrollo.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        // Redirecciona peticiones HTTP hacia peticiones HTTPS
        app.UseHttpsRedirection();

        // Registrar los endpoints de la aplicación
        app.UseSpecialsEndpoints();
        app.UseToppingsEndpoints();
        app.UseOrdersEndpoints();

        // Agregar el Middleware CORS
        app.UseCors();

        return app;
    }
}

