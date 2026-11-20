using System.Reflection;
using NovaBusinessSystem.BL.Services;
using NovaBusinessSystem.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddProblemDetails();
builder.Services.AddControllers();

var assemblies = new[]
{
    typeof(EmployeesService).Assembly,
    typeof(EmployeesRepository).Assembly
}.Distinct();

foreach (var assembly in assemblies)
{
    foreach (var implementation in assembly.GetTypes().Where(type =>
        type.IsClass && !type.IsAbstract && !type.IsGenericType))
    {
        foreach (var serviceInterface in implementation.GetInterfaces()
            .Where(serviceInterface =>
                serviceInterface.Name == $"I{implementation.Name}"))
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
    app.UseDeveloperExceptionPage();

    app.MapOpenApi();

    app.UseSwaggerUI(options =>
        options.SwaggerEndpoint(
            "/openapi/v1.json",
            "Nova Business System"));
}
else
{
    app.UseExceptionHandler();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();