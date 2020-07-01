using Application.DataTransfer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Implementation.Validators
{
    public class UploadFileValidator : AbstractValidator<UploadDto>
    {
        public UploadFileValidator() { 
        RuleFor(x => x.Image).NotEmpty().WithMessage("Please select file");}
    }
}
