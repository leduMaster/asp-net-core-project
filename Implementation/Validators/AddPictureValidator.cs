using System;
using System.Collections.Generic;
using System.Text;
using Application.DataTransfer;
using FluentValidation;
using EfDataAccess;
using System.Linq;

namespace Implementation.Validators
{
    public class AddPictureValidator : AbstractValidator<AddPicture>
    {
        public AddPictureValidator(BlogContext context)
        {
            RuleFor(u => u.Src).NotEmpty().MinimumLength(5); 
            RuleFor(x => x.CreatedAt).NotEmpty().
                 Equal(DateTime.Now)
                 .WithMessage("Comment date must be now.");
            RuleFor(u => u.Alt).NotEmpty().MinimumLength(3).MaximumLength(10).WithMessage("Mora biti maksimum 10");
        }
    }
}
