using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using web_basics.business.ViewModels    ;

namespace web_basics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogController : ControllerBase
    {
        business.Domains.Dog domain;

        public DogController(IConfiguration configuration) 
        {
            this.domain = new business.Domains.Dog(configuration);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var Dogs = this.domain.Get();
            return Ok(Dogs);
        }

        [HttpPost]
        [ActionName("AddDog")]
        public IActionResult AddDog([FromBody] Dog dog)
        {
            int id = this.domain.Add(dog);
            if (id > 0)
            {
                dog.Id = id;
                return Ok(dog);
            }
            else
                return BadRequest();
        }
    }
}
