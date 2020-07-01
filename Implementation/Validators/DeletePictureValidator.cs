using System;
using System.Collections.Generic;
using System.Text;
using Application.DataTransfer;
using FluentValidation;
using EfDataAccess;
using System.Linq;

namespace Implementation.Validators
{
    public class DeletePictureValidator : AbstractValidator<PictureDto>
    {
        public DeletePictureValidator(BlogContext context)
        {
            RuleFor(pic => pic.src).NotEmpty();
            RuleFor(pic => pic.alt).NotEmpty();
        }
    }
}
