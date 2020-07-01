using Application.Commands;
using Application.DataTransfer;
using Application.Responses;
using Application.Searches;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Commands
{
    public class EfGetUsersCommand : EfBaseCommand, IGetUsersCommand
    {
        public EfGetUsersCommand(BlogContext context) : base(context)
        {
        }

        public int Id => 24;

        public string Name => "Get All Users";

        public Pagination<UserDto> Execute(UserSearch querry)
        {
            var query = Context.Users.Include(u => u.UserUseCases).AsQueryable();

            if (querry.UserName != null)
            {
                query = query.Where(p => p.UserName
                .ToLower()
                .Contains(querry.UserName.ToLower()));
            }
            if (querry.LastName != null)
            {
                query = query.Where(p => p.LastName
                .ToLower()
                .Contains(querry.LastName.ToLower()));
            }
            if (querry.FirstName != null)
            {
                query = query.Where(p => p.FirstName
                .ToLower()
                .Contains(querry.FirstName.ToLower()));
            }
            if (querry.IsDeleted.HasValue)
            {
                query = query.Where(p => p.IsDeleted != querry.IsDeleted);
            }

            var totalCount = query.Count();

            query = query.Skip((querry.PageNumber - 1) * querry.PerPage).Take(querry.PerPage);

            var pagesCount = (int)Math.Ceiling((double)totalCount / querry.PerPage);

            return new Pagination<UserDto>
            {
                CurrentPage = querry.PageNumber,
                Pages = pagesCount,
                Total = totalCount,
                Data = query
                .Select(u => new UserDto
                {
                    id = u.Id,
                    UserName = u.UserName,
                    LastName = u.LastName,
                    Email = u.Email,
                    FirstName = u.UserName,
                    UserUseCase = u.UserUseCases.Select(uc => new UserUseCaseDto {                     
                        UseCaseId= uc.UseCaseId
                    })
                })
            };
        }
    }
}
