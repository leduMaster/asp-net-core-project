using Domain;
using EfDataAccess;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Logger
{
    public class DBUseCaseLogger : IUseCaseLogger
    {
        private readonly BlogContext context;

        public DBUseCaseLogger(BlogContext context)
        {
            this.context = context;
        }
        public void Log(IUseCase useCase, IApplicationActor actor, object UseCaseData)
        {
            context.UseCaseLogs.Add(new UseCaseLogs
            {
                Actor = actor.Identity,
                Data = JsonConvert.SerializeObject(UseCaseData),
                Date = DateTime.Now,
                UseCaseName = useCase.Name
            });
           // context.SaveChanges();
        }
    }
}
