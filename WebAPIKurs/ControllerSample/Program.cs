using ControllerSample.Data;
using ControllerSample.Formatter;
using ControllerSample.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApiContrib.Core.Formatter.Csv;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MovieDbContext>(options =>
{
    //options.UseInMemoryDatabase("MovieDB");
    options.UseSqlServer(builder.Configuration.GetConnectionString("MovieDbContext"));
});


// Add services to the container.

builder.Services.AddControllers(options=>
{
    options.InputFormatters.Insert(0, new VCardInputFormatter());
    options.OutputFormatters.Insert(0, new VCardOutputFormatter());
}).AddXmlSerializerFormatters()
  .AddCsvSerializerFormatters();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IContactRepository, ContactRepository>();
builder.Services.AddScoped<ITimeService, TimeService>();

//VideoService
//AddHttpClient besagt, dass innerhalb von VideoService die IHttpClient - Factory verwendet wird 
builder.Services.AddHttpClient<IVideoService, VideoService>();

var app = builder.Build();



using (IServiceScope scope = app.Services.CreateScope()) //Geht seit .NET Core 2.1
{
    SeedData.Initialize(scope.ServiceProvider); 
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
