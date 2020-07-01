using Application;
using Domain;
using EfDataAccess;
using Implementation.Commands;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Logger
{
    public class DBUseCaseLogger : EfBaseCommand, IUseCaseLogger
    {
        public DBUseCaseLogger(BlogContext context) : base(context)
        {
        }

        public void Log(IUseCase useCase, IApplicationActor actor, object UseCaseData)
        {
            Context.UseCaseLogs.Add(new UseCaseLogs
            {
                Actor = actor.Identity,
                Data = JsonConvert.SerializeObject(UseCaseData),
                Date = DateTime.Now,
                UseCaseName = useCase.Name
            });
            Context.SaveChanges();
        }
    }
}
