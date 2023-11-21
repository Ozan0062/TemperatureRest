using Microsoft.AspNetCore.Mvc;
using TemperatureRest.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TemperatureRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperatureController : ControllerBase
    {
        private TemperatureRepository _temperatureRepository;

        public TemperatureController(TemperatureRepository temperatureRepository)
        {
            _temperatureRepository = temperatureRepository;
        }

        // GET: api/<TemperatureController>
        [HttpGet]
        public ActionResult<IEnumerable<TemperatureRepository>> Get()
        {
            return Ok(_temperatureRepository.Get());
        }

        // GET api/<TemperatureController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TemperatureController>
        [HttpPost]
        public ActionResult<TemperatureLib> Post([FromBody] TemperatureLib newTemperatureLib)
        {
            if (newTemperatureLib == null)
            {
                return BadRequest();
            }
            var addedTemperatureLib = _temperatureRepository.Add(newTemperatureLib);
            return CreatedAtAction(nameof(Get), new { id = addedTemperatureLib.Id }, addedTemperatureLib);
        }

        // PUT api/<TemperatureController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TemperatureController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
