using Application.Commands;
using Application.DataTransfer;
using Application.Exceptions;
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
    public class EfGetCommentsCommand : EfBaseCommand, IGetCommentsCommand
    {
        public EfGetCommentsCommand(BlogContext context) : base(context)
        {
        }

        public int Id => 22;

        public string Name => "Get All Comments";
        public Pagination<CommentDto> Execute(CommentSearch request)
        {
            var query = Context.Comments.AsQueryable();

            if (request.Keyword != null)
            {
                query = query.Where(p => p.Text
                .ToLower()
                .Contains(request.Keyword.ToLower()));
            }

            if (request.IsDeleted)
            {
                query = query.Where(p => p.IsDeleted == request.IsDeleted);
            }
            if (!request.IsDeleted)
            {
                query = query.Where(p => p.IsDeleted == request.IsDeleted);
            }

            var totalCount = query.Count();

            query = query.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            return new Pagination<CommentDto>
            {
                CurrentPage = request.PageNumber,
                Pages = pagesCount,
                Total = totalCount,
                Data = query.Include(u => u.User)
                .Select(p => new CommentDto
                {
                    id = p.Id,
                    IsDeleted =p.IsDeleted,
                    CreatedAt = p.CreatedAt,
                    ModifidedAt = p.CreatedAt,
                    Text = p.Text,
                    UserId = p.UserId,
                    PostId = p.PostId
                })
            };
        }      
    }
}
