using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.Commands;
using Application.DataTransfer;
using Application.Exceptions;
using Application.Searches;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly UseCaseExecutor executor;

        public TagController(UseCaseExecutor executor)
        {
            this.executor = executor;
        }

        // GET: api/<TagController>
        [HttpGet]
        public IActionResult Get([FromQuery] TagSearch dto, [FromServices] IGetTagsCommand query) =>
            Ok(executor.ExecuteQuery(query,dto));

        // GET api/<TagController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetTagCommand command)
        {
            try
            {
                
                return Ok(executor.ExecuteQuery(command, id));
            }
            catch (EntityNotFoundException)
            {

                return NotFound();
            }
        }

        // POST api/<TagController>
        [HttpPost]
        public IActionResult Post([FromBody] AddTag dto, [FromServices] ICreateTagCommand command)
        {
            try
            {
                executor.ExecuteCommand(command, dto);
                return StatusCode(202, "Sucessfully added new tag.");
            }
            catch
            {

                return StatusCode(422, "Error has been acured!");
            }
        }

        // PUT api/<TagController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AddTag dto, [FromServices] IEditTagCommand command)
        {
            try
            {
                dto.Id = id;
                executor.ExecuteCommand(command,dto);
                return StatusCode(204, "Sucess in editing!");

            }
            catch
            {
                return StatusCode(422, "Fail!");
            }
        }

        // DELETE api/<TagController>/5
        [HttpDelete("{id}")] 
        public IActionResult Delete(int id, [FromServices] IDeleteTagCommand command)
        {
            try
            {
                executor.ExecuteCommand(command,id);
                return StatusCode(204, "uspeh");
            }
            catch
            {
                return StatusCode(422, "Fail!");
            }
        }
    }
}
