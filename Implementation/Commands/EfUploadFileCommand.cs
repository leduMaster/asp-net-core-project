using Application.Commands;
using Application.DataTransfer;
using EfDataAccess;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Implementation.Commands
{
    public class EfUploadFileCommand : EfBaseCommand, IUploadFileCommand
    {
        private readonly UploadFileValidator _validator;
        public EfUploadFileCommand(BlogContext context, UploadFileValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 26;

        public string Name => "File Upload Command";

        public void Execute(UploadDto request)
        {
            _validator.ValidateAndThrow(request);

            var guid = Guid.NewGuid();
            var extension = Path.GetExtension(request.Image.FileName);

            var newFileName = guid + extension;
            var path = Path.Combine("wwwroot", "images", newFileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                request.Image.CopyTo(fileStream);
            }
            
        }
    }
}
