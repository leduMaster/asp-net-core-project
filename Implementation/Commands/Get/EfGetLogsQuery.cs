using Application.Commands;
using Application.DataTransfer;
using Application.Responses;
using Application.Searches;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands
{
    public class EfGetLogsQuery : EfBaseCommand, IGetLogsCommand
    {
        public EfGetLogsQuery(BlogContext context) : base(context)
        {
        }

        public int Id => throw new NotImplementedException();

        public string Name => throw new NotImplementedException();

        public Pagination<LogsDto> Execute(LogSearch querry)
        {
            throw new NotImplementedException();
        }
    }
}
