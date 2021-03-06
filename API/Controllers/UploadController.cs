﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.Commands;
using Application.DataTransfer;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;
        private readonly IApplicationActor actor;

        public UploadController(UseCaseExecutor executor, IApplicationActor actor)
        {
            this._executor = executor;
            this.actor = actor;
        }
        // POST api/<UploadController>
        [HttpPost]
        public void Post([FromForm] UploadDto dto, [FromServices] IUploadFileCommand command)
        {
            _executor.ExecuteCommand(command, dto);
        }
    }
}
