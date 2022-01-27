using DI_with_WebAPI.Services;
using GoodCar;
using GoodCar.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSingleton<ICar, MockCar>();
builder.Services.AddScoped<ITimeService, TimeService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

/// <summary>
/// Hier können wir auch schon auf den IOC Container zugreifen
/// </summary>

////Frühste Möglichkeit auf den IOC Container zu zugreifen 
using (IServiceScope scope = app.Services.CreateScope()) //Geht seit .NET Core 2.1
{
    //GetRequiredService -> Wenn im IOC Container der Eintrag nicht gefunden wird, liefert GetRequiredService eine Exception
    //GetService -> Wenn im IOC Container der Eintrag nicht gefunden wird, liefert GetService NULL zurück

    ICar car = scope.ServiceProvider.GetRequiredService<ICar>();
    ICar? car1 = scope.ServiceProvider.GetService<ICar>();


    ITimeService timeService = scope.ServiceProvider.GetRequiredService<ITimeService>();
    ITimeService? timeService2 = scope.ServiceProvider.GetService<ITimeService>();
}

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
