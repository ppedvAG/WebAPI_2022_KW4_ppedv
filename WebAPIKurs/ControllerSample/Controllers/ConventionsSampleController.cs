using ControllerSample.Data;
using ControllerSample.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControllerSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController] //ApiController besagt, dass diese WebAPI Controller-Klasse ist
    //[ApiConventionType(typeof(DefaultApiConventions))]

    //[Produces("application/xml")]
    public class ConventionsSampleController : ControllerBase
    {
        private readonly IContactRepository contactRepository;

        public ConventionsSampleController(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }

        [HttpGet]
        //URL -> https://localhost:5001/api/ConventionsSample/
        //[ProducesResponseType(typeof(Contact), StatusCodes.Status200OK)]
        public ActionResult<List<Contact>> GetContacts()
        {
            return Ok(contactRepository.GetAll());
        }

        [HttpGet("/Test1")]
        //URL -> https://localhost:5001/api/ConventionsSample/
        //[ProducesResponseType(typeof(Contact), StatusCodes.Status200OK)]
        public ActionResult<IList<Contact>> GetContactsTest1()
        {
            return Ok(contactRepository.GetAll());
        }

        [HttpGet("/Test1Async")]
        //URL -> https://localhost:5001/api/ConventionsSample/
        //[ProducesResponseType(typeof(Contact), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetContactsTest2()
        {
            await Task.Delay(100);
            return Ok(contactRepository.GetAll());
        }



        //URL -> https://localhost:5001/api/ConventionsSample/123
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Contact), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Contact), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Contact), StatusCodes.Status400BadRequest)]
        public ActionResult<Contact> GetContact(string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest();

            Contact currentContact = contactRepository.Get(id);

            if (currentContact == null)
                return NotFound(); //404

            return Ok(currentContact); //200
        }


        [HttpPost]
        public IActionResult Post(Contact contact)
        {
            contactRepository.Add(contact);

            return CreatedAtAction("GetContact", new { id = contact.ID }, contact); //201
        }



        [HttpPut("{id}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))] //Sammlung von ProducesResponseTypes
        public IActionResult Update(string id, Contact contact)
        {
            if (id != contact.ID)
            {
                return BadRequest(); //400
            }

            contactRepository.Update(contact);

            return NoContent(); //204
        }


        [HttpDelete]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        public IActionResult DeleteMovie (string id)
        {
            contactRepository.Remove(id);
            return NoContent();
        }



    }
}
