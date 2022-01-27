using ControllerSample.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControllerSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReturnTypesController : ControllerBase
    {
        #region Native Datatypes

        // string wird als Zeichenkette ausgelierfert -> JSON wird hier nicht ausgegben 
        [HttpGet("/GetCurrentTime")]
        public string GetCurrentTime()
        {
            return DateTime.Now.ToString();
        }

        // ContentResult liefert ein string zurücl
        [HttpGet("/GetCurrentTime2")]
        public ContentResult GetCurrentTime2()
        {
            return Content(DateTime.Now.ToString());
        }

        //int, float, decimal werden auch als Zeichenketten ausgegeben (kein JSON) 

        #endregion


        #region Komplexe-Object
        // Objekte lassen sich in JSON ausgaben 
        // Nachteil -> Ich kann keine StatusCodes ausgeben (StatusCodes benötige ich, wenn hier ein Fehler geschieht)
        [HttpGet("/GetComplexObject")]
        public Car GetComplexObject()
        {
            Car car = new Car();
            car.Brand = "BMW";
            car.Model = "Z8";
            car.ConstructYear = 2022;
            return car;
        }

        [HttpGet("/GetCarList")]
        public List<Car> GetCarList()
        {
            Car car = new Car();
            car.Brand = "BMW";
            car.Model = "Z8";
            car.ConstructYear = 2022;

            Car car1 = new Car();
            car1.Brand = "BMW";
            car1.Model = "Z3";
            car1.ConstructYear = 2021;

            List<Car> cars = new List<Car>();
            cars.Add(car1);
            cars.Add(car);
            return cars;
        }
        #endregion
    }
}
