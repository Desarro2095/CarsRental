using MilesCarRental.BM.Location;
using MilesCarRental.BM.Vehicle;
using MilesCarRental.DA.Location;
using MilesCarRental.DA.Vehicle;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IDALocation, DALocation>();
builder.Services.AddScoped<IBMLocation, BMLocation>();
builder.Services.AddScoped<IDAVehicle, DAVehicle>();
builder.Services.AddScoped<IBMVehicle, BMVehicle>();
builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
