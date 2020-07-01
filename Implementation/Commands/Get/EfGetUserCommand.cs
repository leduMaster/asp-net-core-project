using Application.Commands;
using Application.DataTransfer;
using Application.Exceptions;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Commands
{
    public class EfGetUserCommand : EfBaseCommand, IGetUserCommand
    {
        public EfGetUserCommand(BlogContext context) : base(context)
        {
        }

        public int Id => 19;

        public string Name => "Get One User";

        public UserDto Execute(int querry)
        {

            var querrry = Context.Users.Include(u => u.UserUseCases).AsQueryable();
            var user = querrry.FirstOrDefault(user => user.Id == querry);
            if (user == null)
                throw new EntityNotFoundException(querry, typeof(PostDto));
            if (user.IsDeleted == true)
                throw new EntityNotFoundException(querry, typeof(PostDto));

            return new UserDto
            {
                id = user.Id,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                UserUseCase = user.UserUseCases.Select(uc => new UserUseCaseDto {
                    UseCaseId = uc.UseCaseId
                })
            };
        }
    }
}
