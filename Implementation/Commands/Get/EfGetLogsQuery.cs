using Application.Commands;
using Application.DataTransfer;
using Application.Responses;
using Application.Searches;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Commands
{
    public class EfGetLogsQuery : EfBaseCommand, IGetLogsCommand
    {
        public EfGetLogsQuery(BlogContext context) : base(context)
        {
        }

        public int Id => 33;

        public string Name => "Get UseCaseLogs";

        public Pagination<LogsDto> Execute(LogSearch querry)
        {
            var query = Context.UseCaseLogs.AsQueryable();

            if (querry.UseCaseName != null)
            {
                query = query.Where(p => p.UseCaseName
                .ToLower()
                .Contains(querry.UseCaseName.ToLower()));
            }
            
            if (!(querry.DateFrom == null) || !(querry.DateTo == null))
            {
                query = query.Where(x => x.Date >= querry.DateFrom && x.Date <= querry.DateTo);
            }

            var totalCount = query.Count();

            query = query.Skip((querry.PageNumber - 1) * querry.PerPage).Take(querry.PerPage);

            var pagesCount = (int)Math.Ceiling((double)totalCount / querry.PerPage);

            return new Pagination<LogsDto>
            {
                CurrentPage = querry.PageNumber,
                Pages = pagesCount,
                Total = totalCount,
                Data = query.Select(p => new LogsDto
                {
                    Id=p.Id,
                    Actor=p.Actor,
                    UseCaseName=p.UseCaseName,
                    Data=p.Data,
                    Date=p.Date
                })
            };
        }
    }
}
