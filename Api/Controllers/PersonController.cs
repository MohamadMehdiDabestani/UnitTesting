using Api.Model;
using Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonServices _person;

        public PersonController(IPersonServices person)
        {
            _person = person;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_person.GetAll());
        }
        
        [HttpGet("{id}" , Name = "Get")]
        public IActionResult Get(int id)
        {
            var person = _person.Get(id);
            if(person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Person p)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var res = _person.Add(p);

            if(res == null)
            {
                return BadRequest();
            }
            return CreatedAtAction("Get" , new { id=res.Id } , res);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Person p)
        {
            var res = _person.Edite(p);

            if (res == null)
            {
                return BadRequest();
            }
            return Ok(res);
        }
        [HttpDelete("{id}" , Name = "Delete")]
        public IActionResult Delete(int id)
        {
            _person.Delete(id);
            return NoContent();
        }
    }
}
