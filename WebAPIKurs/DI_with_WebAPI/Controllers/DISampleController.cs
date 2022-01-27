using DI_with_WebAPI.Services;
using GoodCar;
using GoodCar.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DI_with_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DISampleController : ControllerBase
    {
        private ICar car;
        private ILogger logger;

        //Konstruktor Injection
        public DISampleController(ICar car, ILogger<DISampleController> logger)
        {
            this.car = car;
            this.logger = logger;
        }

        [HttpGet] 
        public ICar GetMockCar()
        {
            logger.LogInformation("Ich kann hier loggen");
            return car; 
        }


        //FromServices -> schaue in IOC Container und gebe mir ITimeSerivce zurück 
        [HttpGet("/GetCurrentTime")]
        public string GetCurrentTime([FromServices] ITimeService timeService)
        {
            logger.LogInformation("Ich kann auch hier loggen");
            return timeService.GetCurrentTime();
        }




        
    }
}
