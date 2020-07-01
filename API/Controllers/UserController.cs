using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.Commands;
using Application.DataTransfer;
using Application.Exceptions;
using Application.Searches;
using Implementation.Commands;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UseCaseExecutor executor;
        private readonly IApplicationActor actor;

        public UserController(UseCaseExecutor executor, IApplicationActor actor)
        {
            this.executor = executor;
            this.actor = actor;
        }
        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get([FromQuery] UserSearch query, [FromServices] IGetUsersCommand command) => Ok(executor.ExecuteQuery(command, query));


        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetUserCommand command)
        {
            try
            {
                var userDto = executor.ExecuteQuery(command, id);
                return Ok(userDto);
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

        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromBody] AddUser dto, [FromServices] ICreateUserCommand command)
        {
            try
            {
                executor.ExecuteCommand(command, dto);
                return StatusCode(202, "User added");
            }
            catch (EntityAllreadyExists)
            {

                return StatusCode(422, "Fail");
            }
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] AddUser dto, [FromServices] IEditUserCommand command)
        {
            try
            {
                dto.UserName = id;
                executor.ExecuteCommand(command, dto);
                return StatusCode(201, "User edited");

            }
            catch
            {
                return StatusCode(422, "Fail");
            }
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteUserCommand command)
        {
            try
            {
                executor.ExecuteCommand(command, id);
                return StatusCode(204, "User deleted");
            }
            catch
            {

                return StatusCode(422, "Fail");
            }
        }
    }
}
