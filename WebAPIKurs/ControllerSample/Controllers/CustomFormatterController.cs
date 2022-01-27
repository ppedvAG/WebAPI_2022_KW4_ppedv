using ControllerSample.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControllerSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomFormatterController : ControllerBase
    {
        [HttpGet]
        public Contact GetContact() //Out Formatter 
        {
            Contact contact = new Contact();
            contact.ID = "1";
            contact.FirstName = "Otto";
            contact.LastName = "Walkes";

            return contact;
        }


        [HttpPost]
        public IActionResult Insert(Contact contact) //Input Formatter 
        {
            return Ok();
        }
    }
}
