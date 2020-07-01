using Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands
{
    public interface IUploadFileCommand : ICommand<UploadDto>
    {
    }
}
