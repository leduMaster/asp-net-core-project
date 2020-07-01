using Application.Commands;
using Application.DataTransfer;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands
{
    public class EfGetCommentCommand : EfBaseCommand, IGetCommentCommand
    {
        
        public EfGetCommentCommand(BlogContext context) : base(context)
        {
        }

        public int Id => 17;

        public string Name => "Get One Comment";

        public CommentDto Execute(int querry)
        {

            var comment = Context.Comments.Find(querry);
            if (comment == null)
                throw new EntityNotFoundException(querry, typeof(PostDto));
            if (comment.IsDeleted == true)
                throw new EntityNotFoundException(querry, typeof(PostDto));
            return new CommentDto
            {
                id = comment.Id,
                Text = comment.Text,
                CreatedAt = comment.CreatedAt,
                ModifidedAt = comment.ModifidedAt,
                UserId = comment.UserId
            };
        }
    }
}
