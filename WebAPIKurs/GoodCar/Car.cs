using GoodCar.Interfaces;

namespace GoodCar
{
    //Programmierer A benötig 5 Tage
    public class Car : ICar
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int ConstructionYear { get; set; }
    }

    public class CarV2 : ICarV2
    {
        public string Color { get; set; }
        public bool WithHitch { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int ConstructionYear { get; set; }
    }
}