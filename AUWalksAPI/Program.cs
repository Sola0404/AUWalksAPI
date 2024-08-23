using AUWalksAPI.Data;
using AUWalksAPI.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AUWalksDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AUWalksConnectionString")));

// Register the SQLRegionRepository as the implementation of the IRegionRepository
// Whenever a service requests an IRegionRepository, the SQLRegionRepository will be provided
builder.Services.AddScoped<IRegionRepository, SQLRegionRepository>();

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
