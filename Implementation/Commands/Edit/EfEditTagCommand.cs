using Application.Commands;
using Application.DataTransfer;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using Implementation.Validators;
using FluentValidation;
using System.Linq;
using Application.Exceptions;

namespace Implementation.Commands
{
    public class EfEditTagCommand : EfBaseCommand, IEditTagCommand
    {
        private readonly EditTagValidator _validator;
        public EfEditTagCommand(BlogContext context, EditTagValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id =>10;

        public string Name => "Edit Tag";

        public void Execute(AddTag request)
        {
            _validator.ValidateAndThrow(request); var tag = new Domain.Tag
            {
                Content = request.Content,
                ModifidedAt = DateTime.Now,
                IsDeleted = false
            };
            if (Context.Tag.Any(t => t.Content == request.Content))
            {
                throw new EntityAllreadyExists("Id: "+ tag.Id+" tip: "+ typeof(AddTag));
            }
            Context.Tag.Add(tag);
            try
            {
                Context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
