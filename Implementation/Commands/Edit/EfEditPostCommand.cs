using Application.Commands;
using Application.DataTransfer;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using Implementation.Validators;
using FluentValidation;
using Domain;
using Application.Exceptions;

namespace Implementation.Commands
{
    public class EfEditPostCommand : EfBaseCommand, IEditPostCommand
    {
        private readonly EditPostValidator _validator;
        public EfEditPostCommand(EditPostValidator validator, BlogContext context) : base(context)
        {
            this._validator = validator;
        }

        public int Id => 5;

        public string Name => "Edit Post";

        public void Execute(AddPost request)
        {
            _validator.ValidateAndThrow(request);

            var potDto = Context.Posts.Find(request);            
            if (potDto != null)
            {
                try
                {
                    potDto.Name = request.Name;
                    potDto.UserId = request.UserId;
                    potDto.IsDeleted = false;
                    potDto.Description = request.Description;
                    potDto.ModifidedAt = DateTime.Now;
                    Context.SaveChanges();
                }
                catch (Exception)
                {

                    throw new Exception();
                }
            }
            else
            {
                throw new EntityNotFoundException(potDto.Id, typeof(AddPost));
            }
        }
    }
}
