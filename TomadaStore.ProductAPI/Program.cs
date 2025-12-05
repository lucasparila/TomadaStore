using TomadaStore.ProductAPI.Controllers.Interfaces;
using TomadaStore.ProductAPI.Data;
using TomadaStore.ProductAPI.Repository;
using TomadaStore.ProductAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.Configure<MongoDBSettings>(
    builder.Configuration.GetSection("MongoDB"));
builder.Services.AddSingleton<ConnectionDB>();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IproductRepository, ProductRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
