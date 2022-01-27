// See https://aka.ms/new-console-template for more information
using GoodCar;
using GoodCar.Interfaces;
using GoodCar.Service;

ICar myCar = new Car(); //Car dauiert 5 Tage
myCar.Brand = "BMW";
myCar.Model = "3er";
myCar.ConstructionYear = 2011;

ICarService service = new CarService(); //Dauet 3 Tage
service.Repair(myCar); //lose Kopplung 

service.Repair(new MockCar()); //Testen für 2 Tage
service.Repair(new Car()); //Testen für 2 Tage

ICarV2 carV2 = new CarV2();
carV2.Brand = "Porsche";
carV2.Model = "911er";
carV2.ConstructionYear = 1999;
carV2.Color = "blue";
carV2.WithHitch = true;

service.Repair(carV2); //Hier nehme ich nur die Teilmenge von ICar
service.RepairV2(carV2); //Nimmt er alle Properties


