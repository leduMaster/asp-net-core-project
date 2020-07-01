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
    public class EfGetPicturesCommand : EfBaseCommand, IGetPicturesCommand
    {
        public EfGetPicturesCommand(BlogContext context) : base(context)
        {
        }

        public int Id => 23;

        public string Name => "Get All Pictures";

        public Pagination<PictureDto> Execute(PictureSearch querry)
        {
            var query = Context.Pictures.AsQueryable();

            if (querry.Keyword != null)
            {
                query = query.Where(p => p.src
                .ToLower()
                .Contains(querry.Keyword.ToLower()));
            }

            if (querry.Alt != null)
            {
                query = query.Where(p => p.alt
               .ToLower()
               .Contains(querry.Keyword.ToLower()));
            }

            var totalCount = query.Count();

            query = query.Skip((querry.PageNumber - 1) * querry.PerPage).Take(querry.PerPage);

            var pagesCount = (int)Math.Ceiling((double)totalCount / querry.PerPage);

            return new Pagination<PictureDto>
            {
                CurrentPage = querry.PageNumber,
                Pages = pagesCount,
                Total = totalCount,
                Data = query.Include(p => p.Post)
                .Select(p => new PictureDto
                {
                    id = p.Id,
                    alt = p.alt,
                    src= p.src,
                    PostId = p.Post.Id,
                    CreatedAt= p.CreatedAt
                })
            };
        }
    }
}
