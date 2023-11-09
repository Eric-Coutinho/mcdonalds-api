using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using mcdonalds_api.Model;
using mcdonalds_api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// builder.Services.AddSingleton<McDataBaseContext>();
builder.Services.AddScoped<McDataBaseContext>();
// builder.Services.AddSingleton<IOrderRepository, FakeOrderRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
