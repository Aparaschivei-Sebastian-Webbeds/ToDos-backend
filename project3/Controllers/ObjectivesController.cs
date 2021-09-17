using Microsoft.AspNetCore.Mvc;
using project3.Data;
using project3.DTOS;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace project3.Controllers
{
    [Route("objectives")]
    [ApiController]
    public class ObjectivesController : ControllerBase
    {
        private readonly MyDbContext _context;
        public ObjectivesController(MyDbContext context)
        {
            _context = context;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult Get()
        {
            var data = _context.Objectives.ToList();
            if (data != null)
            {
                return Ok(data);
            }
            else return NotFound("Objective not found");
        }

        
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var objective = _context.Objectives.Where(x => x.Id == id).First();
            if (objective != null)
            { 
                return Ok(objective); 
            }
            else
            {
                return NotFound("Resource Not found");
            }
        }

       
        [HttpPost]
        public IActionResult Post([FromBody] PostDto parameter)
        {
            var objective = new Objective();
            objective.Id = Guid.NewGuid();
            objective.Text = parameter.text;
            objective.completed = false;
            _context.Objectives.Add(objective);
            _context.SaveChanges();
            return Created("New objective created",objective);
        }

        
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] PutDto objectiveParameter)
        {
            Console.WriteLine("oP: " + objectiveParameter);
            Console.WriteLine("oP.c: "+objectiveParameter.completed);
            var objective = _context.Objectives.Where(x => x.Id == id).First();
            objective.completed = objectiveParameter.completed;
            _context.SaveChanges();
            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
           var objective= _context.Objectives.Where(x=>x.Id==id).FirstOrDefault();
            _context.Remove(objective);
            _context.SaveChanges();
            if(objective != null)
            {
                return Ok($"Objective with id {id} deleted");
            }
            else
            {
                return NotFound("Objective not found");
            }
        }
    }
}
