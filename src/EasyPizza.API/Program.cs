using EasyPizza.Application;
using EasyPizza.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddApiVersioning(x =>
{
    x.DefaultApiVersion = new ApiVersion(1.0);
    x.AssumeDefaultVersionWhenUnspecified = true;
    x.ReportApiVersions = true;
    x.ApiVersionReader = new MediaTypeApiVersionReader("api-version");
}).AddMvc();

builder.Services.AddControllers();

builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = null);

builder.Services.AddHealthChecks().AddDbContextCheck<EasyPizzaDbContext>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapHealthChecks("_health");

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseMiddleware<ValidationMappingMiddleware>();
app.MapControllers();

app.Run();