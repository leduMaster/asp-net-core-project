using Application.Commands;
using Application.DataTransfer;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Implementation.Validators;
using FluentValidation;

namespace Implementation.Commands
{
    public class EfAddUserCommand : EfBaseCommand, ICreateUserCommand
    {
        private readonly AddUserValidator _validator;

        public EfAddUserCommand(BlogContext context, AddUserValidator validator) : base(context)
        {
         _validator = validator;
        }


        public int Id => 4;

        public string Name => "Add User";

        public void Execute(AddUser request)
        {
            _validator.ValidateAndThrow(request);
            var userDto = new Domain.User
            {
                IsDeleted = false,
                FirstName = request.FirstName,
                LastName = request.LastName,
                CreatedAt = DateTime.Now,
                ModifidedAt = null,
                UserName = request.UserName
            };
            if (Context.Users.Any(u => u.UserName == userDto.UserName))
                throw new EntityAllreadyExists("User");

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
