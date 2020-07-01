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
    public class PictureController : ControllerBase
    {
        private readonly UseCaseExecutor executor;
        private readonly IApplicationActor actor;

        public PictureController(UseCaseExecutor executor, IApplicationActor actor)
        {
            this.executor = executor;
            this.actor = actor;
        }

        // GET: api/<PictureController>
        [HttpGet]
        public IActionResult Get([FromQuery] PictureSearch dto, [FromServices] IGetPicturesCommand query) => Ok(executor.ExecuteQuery(query,dto));


        // GET api/<PictureController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetPictureCommand pci)
        {
            try
            {                
                return Ok(executor.ExecuteQuery(pci, id));
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

        // POST api/<PictureController>
        [HttpPost]
        public IActionResult Post([FromBody] AddPicture dto, [FromServices] ICreatePictureCommand com)
        {
            try
            {
                executor.ExecuteCommand(com, dto);
                return StatusCode(202, "Picture added");
            }
            catch (EntityAllreadyExists)
            {

                return StatusCode(422, "Fail");
            }
        }

        // PUT api/<PictureController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AddPicture dto, [FromServices] ICreatePictureCommand com)
        {
            try
            {
                dto.Id = id;
                executor.ExecuteCommand(com,dto);
                return StatusCode(201, "Picture edited");

            }
            catch
            {
                return StatusCode(422, "Fail");
            }
        }

        // DELETE api/<PictureController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeletePictureCommand com)
        {
            try
            {
                executor.ExecuteCommand(com, id);
                return StatusCode(204, "Picture deleted");
            }
            catch
            {

                return StatusCode(422, "Fail");
            }
        }
    }
}
