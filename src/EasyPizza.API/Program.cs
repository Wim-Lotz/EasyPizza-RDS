using EasyPizza.Application;
using EasyPizza.Application.Interfaces;
using EasyPizza.Infrastructure;
using EasyPizza.Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationServices();

builder.Services.AddDbContext<EasyPizzaDbContext>();
builder.Services.AddScoped<IEasyPizzaDbContext>(provider => provider.GetRequiredService<EasyPizzaDbContext>());

builder.Services.AddScoped<IIngredientService, IngredientService>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetIngredientsQuery>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();