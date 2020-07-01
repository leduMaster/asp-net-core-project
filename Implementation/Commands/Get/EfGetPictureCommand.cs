using Application.Commands;
using Application.DataTransfer;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands
{
    public class EfGetPictureCommand : EfBaseCommand, IGetPictureCommand
    {
        public EfGetPictureCommand(BlogContext context) : base(context)
        {
        }

        public int Id =>18;

        public string Name => "Get One Picture";

        public PictureDto Execute(int querry)
        {
            var pic = Context.Pictures.Find(querry);
            if (pic == null)
                throw new EntityNotFoundException(querry, typeof(PostDto));
            if (pic.IsDeleted == true)
                throw new EntityNotFoundException(querry, typeof(PostDto));
            return new PictureDto
            {
                id = pic.Id,
                src = pic.src,
                CreatedAt = pic.CreatedAt,
                ModifidedAt = pic.ModifidedAt,
                alt = pic.alt,
                PostId = pic.PostId
            };
        }
    }
}
