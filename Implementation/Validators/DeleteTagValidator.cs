using System;
using System.Collections.Generic;
using System.Text;
using Application.DataTransfer;
using FluentValidation;
using EfDataAccess;
using System.Linq;

namespace Implementation.Validators
{
    public class DeleteTagValidator : AbstractValidator<TagDto>
    {
        public DeleteTagValidator(BlogContext context)
        {
       
        RuleFor(x => x.Content).NotEmpty();         
        RuleFor(x => x.id)
                .NotEmpty()
               // .Must(x => !context.Tag.Any(t => t.Id == x.id))
                .Must(x => !context.Tag.Any(x=> x.IsDeleted))
                .WithMessage("Tag allready deleted.");
            
        }
    }
}
