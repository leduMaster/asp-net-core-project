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
    public class CommentController : ControllerBase
    {
        private readonly UseCaseExecutor executor;

        public CommentController(UseCaseExecutor executor)
        {
            this.executor = executor;
        }



        // GET: api/<CommentController>
        [HttpGet]
        public IActionResult Get([FromQuery] CommentSearch dto, [FromServices] IGetCommentsCommand query) => Ok(executor.ExecuteQuery(query, dto));

        // GET api/<CommentController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetCommentCommand query)
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

        // POST api/<CommentController>
        [HttpPost]
        public IActionResult Post([FromBody] AddComment dto, [FromServices] ICreateCommentCommand com)
        {
            try
            {
                executor.ExecuteCommand(com, dto);
                return StatusCode(202, "Comment added");
            }
            catch (EntityAllreadyExists)
            {

                return StatusCode(422, "Fail");
            }
        }

        // PUT api/<CommentController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AddComment dto, [FromServices] IEditCommentCommand command)
        {
            try
            {
                dto.Id = id;
                executor.ExecuteCommand(command, dto);
                return StatusCode(201, "Comment edited");
            }
            catch
            {
                return StatusCode(422, "Fail");
            }
        }

        // DELETE api/<CommentController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteCommentCommand command)
        {
            try
            {
                executor.ExecuteCommand(command, id);
                return StatusCode(204, "Comment deleted");
            }
            catch
            {

                return StatusCode(422, "Fail");
            }
        }
    }
}
