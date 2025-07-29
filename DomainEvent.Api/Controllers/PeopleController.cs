using DomainEvent.ApplicationService;
using Microsoft.AspNetCore.Mvc;

namespace DomainEvent.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly PersonService _service;

        public PeopleController(PersonService service)
        {
            _service = service;
        }

        // GET: api/<PeopleController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }

        // POST api/<PeopleController>
        [HttpPost("AddPerson")]
        public async Task<IActionResult> AddPerson(string firstName, string lastName)
        {
            await _service.CreatePerson(firstName, lastName);
            
            return Ok();
        }


        [HttpPut("UpdateFirstName/{id}")]
        public async Task<IActionResult> UpdateFirstName(int id, [FromBody] string firstName)
        {
            await _service.UpdateFirsName(id, firstName);
            
            return Ok();
        }

        [HttpPut("UpdateLastName/{id}")]
        public async Task<IActionResult> UpdateLastName(int id, [FromBody] string lastName)
        {
            await _service.UpdateLastName(id, lastName);
            
            return Ok();
        }
    }
}