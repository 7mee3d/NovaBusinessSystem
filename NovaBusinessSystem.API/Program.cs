using NovaBusinessSystem.BL.Products.Reports;
using NovaBusinessSystem.DAL.Products.Reports;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IReportsDAL , ReportsDAL> ();
builder.Services.AddScoped<ReportsBL> ();

builder.Services.AddOpenApi();
builder.Services.AddProblemDetails();
builder.Services.AddControllers();

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