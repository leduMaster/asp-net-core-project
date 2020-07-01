using System;
using System.Collections.Generic;
using System.Text;
using Application.DataTransfer;
using Application.Responses;
using Application.Searches;

namespace Application.Commands
{
    public interface IGetTagsCommand : ICommand<TagSearch, Pagination<TagDto>>
    {
    }
}
