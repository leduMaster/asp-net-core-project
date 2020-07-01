using System;
using System.Collections.Generic;
using System.Text;
using Application.DataTransfer;
namespace Application.Commands
{
    public interface IGetTagCommand : ICommand<int, TagDto>
    {
    }
}
