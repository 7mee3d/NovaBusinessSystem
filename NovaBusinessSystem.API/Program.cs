using System.Reflection;
using NovaBusinessSystem.BL.Services;
using NovaBusinessSystem.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddProblemDetails();
builder.Services.AddControllers();

// Auto-register project dependencies
var assemblies = new[]
{
    typeof(EmployeesService).Assembly,
    typeof(EmployeesRepository).Assembly
}.Distinct();

foreach (var assembly in assemblies)
{
    foreach (var implementation in assembly.GetTypes().Where(t =>
        t.IsClass && !t.IsAbstract && !t.IsGenericType))
    {
        foreach (var serviceInterface in implementation.GetInterfaces()
            .Where(i => i.Name == $"I{implementation.Name}"))
        {
            builder.Services.AddScoped(
                serviceInterface,
                implementation);
        }
    }
}

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseExceptionHandler();
    app.UseSwaggerUI(options =>
        options.SwaggerEndpoint(
            "/openapi/v1.json",
            "Nova Business System"));
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();