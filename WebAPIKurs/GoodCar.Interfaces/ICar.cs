namespace GoodCar.Interfaces
{
    public interface ICar
    {
        string Brand { get; set; }  
        string Model { get; set; }  
        int ConstructionYear { get; set; }
    }
    
    public interface ICarV2 :ICar
    {
        string Color { get; set; }
        bool WithHitch { get; set; }
    }

    
}