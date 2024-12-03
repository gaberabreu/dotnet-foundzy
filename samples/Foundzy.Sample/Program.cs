using Foundzy.Sample.Layers.Web.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Host.AddLoggerConfigs();
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddServiceConfigs();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "v1");
    });
}

app.MapControllers();

await app.RunAsync();
