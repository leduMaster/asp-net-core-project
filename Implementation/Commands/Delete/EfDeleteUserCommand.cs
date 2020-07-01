using Application.Commands;
using Application.DataTransfer;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using Implementation.Validators;
using FluentValidation;

namespace Implementation.Commands
{
    public class EfDeleteUserCommand : EfBaseCommand, IDeleteUserCommand
    {
       
        public EfDeleteUserCommand(BlogContext context) : base(context)
        {
        }

        public int Id => 14;

        public string Name => "Delete User";

        public void Execute(int request)
        {
            var UserDto = Context.Users.Find(request);

            if (UserDto != null)
            {
                try
                {
                    UserDto.IsDeleted = true;
                    Context.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            else throw new EntityNotFoundException(request, typeof(UserDto));
        }
    }
}
