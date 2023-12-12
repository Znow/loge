using Loge.Application;
using Loge.Application.Interfaces;
using Loge.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ITransportOrderService, TransportOrderService>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();