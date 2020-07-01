using Application.DataTransfer;
using Application.Responses;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands
{
    public interface IGetLogsCommand : ICommand<LogSearch, Pagination<LogsDto>>
    {
    }
}
