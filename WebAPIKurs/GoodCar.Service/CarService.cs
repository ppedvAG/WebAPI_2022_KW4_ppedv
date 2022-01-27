using GoodCar.Interfaces;

namespace GoodCar.Service
{
    //Programmierer B: 3 Tage (er kann von Tag 1 starten) 
    public class CarService : ICarService
    {
        public void Repair(ICar car)
        {
            Console.WriteLine(car.Brand + " " + car.Model + " wird repariert");
        }

        public void RepairV2(ICarV2 carv2)
        {
            Console.WriteLine(carv2.Brand + " " + carv2.Model + " wird repariert");
        }
    }
}