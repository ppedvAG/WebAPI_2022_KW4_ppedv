WebApplicationBuilder builder = WebApplication.CreateBuilder(args); //Seperation of Concern (WebApplicationBuilder / WebApplication)


//builder.WebHost -> .NET Core 2.1
//builder.Host -> ab .NET 3.1 bis .NET Core 5

// Add services to the container.


//Aufbau des IOC Containers mit ServiceCollection
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    Console.WriteLine("IsDevelopment");
}

app.UseSwagger();
app.UseSwaggerUI();

if (app.Environment.IsProduction())
{
    Console.WriteLine("IsProduction");
    app.UseHsts(); //Erweiterung für Https 
}
else if (app.Environment.IsStaging())
{
    Console.WriteLine("IsStaging");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
