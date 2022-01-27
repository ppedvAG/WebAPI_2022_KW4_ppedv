using GoodCar;
using GoodCar.Interfaces;
using Microsoft.Extensions.DependencyInjection;

ICar mockCar = new MockCar();


//ServiceCollection sammelt ale Services (Dienste), die später in deiner ASPNETCore Anwendung wiedervendbar gemacht werden
IServiceCollection collection = new   ServiceCollection();
collection.AddSingleton<ICar, MockCar>();
collection.AddSingleton<ICar, Car>(); //überschreibt MockCar durch Car

IServiceProvider serviceProvider = collection.BuildServiceProvider();   //IOC Container wird mit Build erstellt 


//Hier greife ich auf den IOC - Container zu und erhalte eine Instanz (Seperation of Concern) 

//Wenn ich kein Objekt finde, dass ICar implementiert, gebe ich hier eine Exception aus
ICar car = serviceProvider.GetRequiredService<ICar>();

//Wenn ich kein Objekt finde, dass ICar implementiert, gebe ich hier eine NULL aus
ICar? car2 = serviceProvider.GetService<ICar>();

if(car2 != null)
{
    Console.WriteLine(car2.Brand);
}