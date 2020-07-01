using System;
using System.Collections.Generic;
using System.Text;
using Application.DataTransfer;

namespace Application.Commands
{
    public interface ICreateCommentCommand : ICommand<AddComment>
    {
    }
}
