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
using Application.Email;

namespace Implementation.Commands
{
    public class EfAddUserCommand : EfBaseCommand, ICreateUserCommand
    {
        private readonly AddUserValidator _validator;
        private readonly IEmailSender _sender;

        public EfAddUserCommand(BlogContext context, AddUserValidator validator, IEmailSender sender) : base(context)
        {
         _validator = validator;
         _sender = sender;
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
                _sender.Send(new SendEmailDto
                {
                    Content = "<h1>Uspesno ste dodali korisnika</h1>",
                    SendTo = request.Email,
                    Subject = "Registration confirmation!!!"
                });
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
