using RabbitMQ.Client;
using TomadaStore.PaymentAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<IConnectionFactory>(Sp => new ConnectionFactory { HostName = "localhost" });
builder.Services.AddScoped<PaymentService>();
builder.Services.AddHttpClient("ClientCustomer", client => client.BaseAddress = new Uri("https://localhost:5001/api/v1/Customer/"));

builder.Services.AddHttpClient("ClientProduct", client => client.BaseAddress = new Uri("https://localhost:6001/api/v1/Product/"));



var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
