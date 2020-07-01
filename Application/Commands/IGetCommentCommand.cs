using System;
using System.Collections.Generic;
using System.Text;
using Application.DataTransfer;
using Application.Responses;
using Application.Searches;
using Domain;

namespace Application.Commands
{
    public interface IGetCommentCommand : ICommand<int, CommentDto>
    {
    }
}
