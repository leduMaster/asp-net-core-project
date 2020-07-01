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
    public class PostController : ControllerBase
    {

        
        private readonly UseCaseExecutor executor;

        public PostController(UseCaseExecutor executor)
        {
           
            this.executor = executor;
        }
        // GET: api/<PostController>
        [HttpGet]
        public IActionResult Get([FromQuery] PostSearch search, [FromServices] IGetPostsCommand query) => Ok(executor.ExecuteQuery(query, search));

        // GET api/<PostController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetPostCommand query )
        {
            try
            {
                return Ok(executor.ExecuteQuery(query, id)); 
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message.ToString()); ;
            }
        }

        // POST api/<PostController>
        [HttpPost]
        public IActionResult Post([FromBody] AddPost dto, [FromServices] ICreatePostCommand command)
        {

            try
            {
                executor.ExecuteCommand(command, dto);
                return StatusCode(201, "Succesfully added a new post.");

            }
            catch (EntityNotFoundException e)
            {
                if (e.Message == "Product not found.")
                    return NotFound(e.Message);
                return UnprocessableEntity(e.Message);

            }
        }

        // PUT api/<PostController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AddPost dto, [FromServices] IEditPostCommand command)
        {
            try
            {
                dto.Id = id;
                executor.ExecuteCommand(command, dto);
                return StatusCode(204, "Succesfully edited a post");
            }
            catch (EntityNotFoundException e)
            {
                if (e.Message == "Product not found.")
                    return NotFound(e.Message);

                return UnprocessableEntity(e.Message);
            }
        }

        // DELETE api/<PostController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeletePostCommand command)
        {
            try
            {
                  executor.ExecuteCommand(command, id);
                  return StatusCode(200, "Sucessfully deleted!");
            }
            catch
            {
                return StatusCode(422, "Deletion of post not sucesseded!");
            }
        }
    }
}
