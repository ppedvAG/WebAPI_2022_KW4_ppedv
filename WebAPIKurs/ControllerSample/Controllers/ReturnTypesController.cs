using ControllerSample.Models;
using ControllerSample.Services;
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

        [HttpGet("/GetCarWith_IActionResult")]
        public IActionResult GetCarWith_IActionResult()
        {
            Car car = new Car();
            car.Brand = "BMW";
            car.Model = "Z8";
            car.ConstructYear = 2022;

            if (car.Brand != "BMW")
                return BadRequest(); //400 

            if (car.Brand == string.Empty)
                return NotFound(); //404

            

            return Ok(car); //200
        }

        [HttpGet("/GetCarWith_ActionResult")]
        public ActionResult GetCarWith_ActionResult()
        {
            Car car = new Car();
            car.Brand = "BMW";
            car.Model = "Z8";
            car.ConstructYear = 2022;

            if (car.Brand != "BMW")
                return BadRequest(); //400 

            if (car.Brand == string.Empty)
                return NotFound(); //404

            return Ok(car);
        }

        [HttpGet("/GetCarWith_GenericActionResult")]
        public ActionResult<Car> GetCarWith_GenericActionResult()
        {
            Car car = new Car();
            car.Brand = "BMW";
            car.Model = "Z8";
            car.ConstructYear = 2022;

            if (car.Brand != "BMW")
                return BadRequest(); //400 

            if (car.Brand == string.Empty)
                return NotFound(); //404

            return Ok(car);
        }


        //Asynchron 
        [HttpGet("/GetCarWithAsync_ActionResult")]
        public async Task<ActionResult> GetCarWith_ActionResultAsync([FromServices] ITimeService timeService)
        {
            Car car = new Car();
            car.Brand = "BMW";
            car.Model = "Z8";
            car.ConstructYear = 2022;

            await timeService.GetCurrentTime();

            if (car.Brand != "BMW")
                return BadRequest(); //400 

            if (car.Brand == string.Empty)
                return NotFound(); //404

            return Ok(car);
        }

        [HttpGet("/GetCarIEnumerable")]
        public IEnumerable<Car> GetCars()
        {
            Car car = new Car();
            car.Brand = "BMW";
            car.Model = "Z8";
            car.ConstructYear = 2022;

            Car car1 = new Car();
            car1.Brand = "BMW";
            car1.Model = "Z3";
            car1.ConstructYear = 2021;

            IList<Car> cars = new List<Car>();
            cars.Add(car1);
            cars.Add(car);

            
            foreach(Car currentCar in cars)
            {
                yield return currentCar;
            }
        }

        [HttpGet("/GetCarIAsyncEnumerable")]
        public async IAsyncEnumerable<Car> GetCarsAsyncEnumerable()
        {
            Car car = new Car();
            car.Brand = "BMW";
            car.Model = "Z8";
            car.ConstructYear = 2022;

            Car car1 = new Car();
            car1.Brand = "BMW";
            car1.Model = "Z3";
            car1.ConstructYear = 2021;

            Car car2 = new Car();
            car2.Brand = "BMW";
            car2.Model = "3er";
            car2.ConstructYear = 2021;

            Car car3 = new Car();
            car3.Brand = "BMW";
            car3.Model = "JamesBond BMW";
            car3.ConstructYear = 2021;

            Car car4 = new Car();
            car4.Brand = "BMW";
            car4.Model = "ZE";
            car4.ConstructYear = 2028;

            IList<Car> cars = new List<Car>();
            cars.Add(car1);
            cars.Add(car2);
            cars.Add(car3);
            cars.Add(car4);
            cars.Add(car);


            foreach (Car currentCar in cars)
            {
                await Task.Delay(1000);
                yield return currentCar;
            }
        }
        #endregion
    }
}
