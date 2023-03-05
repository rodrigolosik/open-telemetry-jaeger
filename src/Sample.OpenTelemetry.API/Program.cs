using Sample.OpenTelemetry.Core.Configuration;
using Sample.OpenTelemetry.Core.Extensions;

var builder = WebApplication.CreateBuilder(args);

var appSettings = new AppSettings();
builder.Configuration.Bind(appSettings);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = appSettings?.DistributedTracing?.Jaeger?.ServiceName, Version = "v1" });
});

builder.Services.AddServices();
builder.Services.AddOpenTelemetry(appSettings);
builder.Services.AddHttpClient("google");
builder.Services.AddRefit(appSettings);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{appSettings?.DistributedTracing?.Jaeger?.ServiceName} v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
