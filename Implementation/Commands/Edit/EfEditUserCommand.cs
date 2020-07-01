using Application.Commands;
using Application.DataTransfer;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using Implementation.Validators;
using FluentValidation;
using Application.Exceptions;
using System.Linq;

namespace Implementation.Commands
{
    public class EfEditUserCommand : EfBaseCommand, IEditUserCommand
    {
        private readonly EditUserValidator _validator;
        public EfEditUserCommand(BlogContext context, EditUserValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 9;

        public string Name => "Edit User";

        public void Execute(AddUser request)
        {
            _validator.ValidateAndThrow(request); var userDto = new Domain.User
            {
                IsDeleted = false,
                FirstName = request.FirstName,
                LastName = request.LastName,
                ModifidedAt = DateTime.Now,
                UserName = request.UserName
            };
            if (Context.Users.Any(u => u.UserName == userDto.UserName))
                throw new EntityAllreadyExists("Id: "+userDto.Id+" Tip: "+typeof(AddUser));
            try
            {
                Context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
